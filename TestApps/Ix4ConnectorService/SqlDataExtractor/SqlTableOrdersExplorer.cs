using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ix4Models.Interfaces;
using Ix4Models.SettingsDataModel;
using System.Data.SqlClient;
using Ix4Models;
using System.Data;
using System.Reflection;
using SimplestLogger;

namespace SqlDataExtractor
{
    class SqlTableOrdersExplorer : SqlTableWorker
    {
       // private MsSqlPluginSettings _pluginSettings;
      //  private static Logger _loger = Logger.GetLogger();

        public SqlTableOrdersExplorer(IPluginSettings pluginSettings) : base(pluginSettings)
        {
        
        }
        //private string DbConnection
        //{
        //    get
        //    {
        //        return _pluginSettings.DbSettings.UseSqlServerAuth ? string.Format(CurrentServiceInformation.MsSqlDatabaseConnectionStringWithServerAuth, _pluginSettings.DbSettings.ServerAdress,
        //                                                                                                 _pluginSettings.DbSettings.DataBaseName,
        //                                                                                                 _pluginSettings.DbSettings.DbUserName,
        //                                                                                                 _pluginSettings.DbSettings.Password) :
        //                                                            string.Format(CurrentServiceInformation.MsSqlDatabaseConnectionStringWindowsAuth, _pluginSettings.DbSettings.ServerAdress,
        //                                                                                                 _pluginSettings.DbSettings.DataBaseName);

        //        //return   string.Format(CurrentServiceInformation.MsSqlDatabaseConnectionStringWindowsAuth, _pluginSettings.DbSettings.ServerAdress,
        //        //                                                                                    _pluginSettings.DbSettings.DataBaseName);

        //    }
        //}

        internal LICSRequestOrder[] GetRequestOrders()
        {
            LICSRequestOrder[] orders = null;
            try
            {
                using (var connection = new SqlConnection(DbConnection))
                {
                    connection.Open();
                    var cmdText = _pluginSettings.OrdersQuery;
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    orders = LoadOrders(reader, connection);
                    _loger.Log(string.Format("Orders no in SQL Extractor = {0}", orders.Length));
                }
            }
            catch (Exception ex)
            {
                _loger.Log(ex);
            }
            return orders;
        }

        private object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }

        private LICSRequestOrder[] LoadOrders(IDataReader reader, SqlConnection connection)
        {
            DataTable table = new DataTable();
            List<LICSRequestOrder> orders = new List<LICSRequestOrder>();

            table.Load(reader);
            foreach (DataRow row in table.AsEnumerable())
            {
                try
                {
                    LICSRequestOrder orderItem = new LICSRequestOrder();
                    //   articleItem.GetType().GetProperty(propertyName).SetValue.GetValue((car, null);

                    //  var r = table.AsEnumerable();
                    foreach (DataColumn column in row.Table.Columns)
                    {
                        var res = row[column.ColumnName];
                        PropertyInfo propertyInfo = orderItem.GetType().GetProperty(column.ColumnName);
                        if (row[column.ColumnName].GetType().Equals(DBNull.Value.GetType()))
                        {
                            propertyInfo.SetValue(orderItem, Convert.ChangeType(GetDefaultValue(propertyInfo.PropertyType), propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(orderItem, Convert.ChangeType(row[column.ColumnName].ToString().Trim(), propertyInfo.PropertyType), null);
                        }


                    }
                    orderItem.Recipient = GetOrderRecipient(connection, orderItem.ReferenceNo);
                    orderItem.Positions = GetRequestOrderPositions(connection, orderItem.ReferenceNo);
                    orders.Add(orderItem);
                }
                catch (Exception ex)
                {
                    _loger.Log("Exception while reflect DataColumn values using Reflection in LoadOrders");
                    _loger.Log(ex);
                }
            }
            return orders.ToArray();
        }

        private LICSRequestOrderPosition[] GetRequestOrderPositions(SqlConnection connection, string orderId)
        {
            List<LICSRequestOrderPosition> orderPositions = new List<LICSRequestOrderPosition>();

            string getOrderPositionsQuery = string.Format(_pluginSettings.OrderPositionsQuery, orderId);
            SqlCommand cmd = new SqlCommand(getOrderPositionsQuery, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            foreach (DataRow row in table.AsEnumerable())
            {

                try
                {
                    LICSRequestOrderPosition orderPosition = new LICSRequestOrderPosition();

                    foreach (DataColumn column in row.Table.Columns)
                    {
                        var res = row[column.ColumnName];
                        _loger.Log(string.Format("column.ColumnName ={0} value = {1}", (string)column.ColumnName, res.ToString()));
                        PropertyInfo propertyInfo = orderPosition.GetType().GetProperty(column.ColumnName);
                        if (propertyInfo == null)
                        {
                            _loger.Log(propertyInfo, "propertyInfo");
                            continue;
                        }

                        if (row[column.ColumnName].GetType().Equals(DBNull.Value.GetType()))
                        {
                            propertyInfo.SetValue(orderPosition, Convert.ChangeType(GetDefaultValue(propertyInfo.PropertyType), propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(orderPosition, Convert.ChangeType(row[column.ColumnName].ToString().Trim(), propertyInfo.PropertyType), null);
                        }
                    }
                    orderPositions.Add(orderPosition);
                }
                catch (Exception ex)
                {
                    _loger.Log("Exception while reflect DataColumn values using Reflection in GetOrderPositions");
                    _loger.Log(ex);
                }

            }
            return orderPositions.ToArray();
        }

        private LICSRequestOrderRecipient GetOrderRecipient(SqlConnection connection, string referenceNo)
        {
            string getOrderRecipientQuery = string.Format(_pluginSettings.OrderRecipientQuery, referenceNo);
            SqlCommand cmd = new SqlCommand(getOrderRecipientQuery, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();

            table.Load(reader);

            LICSRequestOrderRecipient orderRecipient = new LICSRequestOrderRecipient();
            foreach (DataRow row in table.Rows)
            {
                try
                {
                    foreach (DataColumn column in row.Table.Columns)
                    {
                        var res = row[column.ColumnName];
                        PropertyInfo propertyInfo = orderRecipient.GetType().GetProperty(column.ColumnName);
                        if (propertyInfo != null)
                        {
                            //                _loger.Log("propertyInfo VALIDITY" );
                        }
                        else
                        {
                            //               _loger.Log(propertyInfo, "propertyInfo");
                            continue;
                        }

                        if (row[column.ColumnName].GetType().Equals(DBNull.Value.GetType()))
                        {
                            propertyInfo.SetValue(orderRecipient, Convert.ChangeType(GetDefaultValue(propertyInfo.PropertyType), propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(orderRecipient, Convert.ChangeType(row[column.ColumnName].ToString().Trim(), propertyInfo.PropertyType), null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _loger.Log("Exception while reflect DataColumn values using Reflection in GetOrderPositions");
                    _loger.Log(ex);
                }
            }
            return orderRecipient;
        }
    }
}
