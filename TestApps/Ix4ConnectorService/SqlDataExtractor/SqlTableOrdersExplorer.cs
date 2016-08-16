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
    class SqlTableOrdersExplorer
    {
        private MsSqlPluginSettings _pluginSettings;
        private static Logger _loger = Logger.GetLogger();

        public SqlTableOrdersExplorer(IPluginSettings pluginSettings)
        {
            this._pluginSettings = pluginSettings as MsSqlPluginSettings;
        }
        private string DbConnection
        {
            get
            {
                return _pluginSettings.DbSettings.UseSqlServerAuth ? string.Format(CurrentServiceInformation.MsSqlDatabaseConnectionStringWithServerAuth, _pluginSettings.DbSettings.ServerAdress,
                                                                                                         _pluginSettings.DbSettings.DataBaseName,
                                                                                                         _pluginSettings.DbSettings.DbUserName,
                                                                                                         _pluginSettings.DbSettings.Password) :
                                                                    string.Format(CurrentServiceInformation.MsSqlDatabaseConnectionStringWindowsAuth, _pluginSettings.DbSettings.ServerAdress,
                                                                                                         _pluginSettings.DbSettings.DataBaseName);

                //return   string.Format(CurrentServiceInformation.MsSqlDatabaseConnectionStringWindowsAuth, _pluginSettings.DbSettings.ServerAdress,
                //                                                                                    _pluginSettings.DbSettings.DataBaseName);

            }
        }

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
                    //double currentArticleGroupFactor = 0;
                    //double currentWeight = 0;
                    //int identityNo = 0;
                    //if (!string.IsNullOrEmpty(Convert.ToString(row["ArticleGroupFactor"])))
                    //{
                    //    currentArticleGroupFactor = double.Parse(Convert.ToString(row["ArticleGroupFactor"]), CultureInfo.InvariantCulture);
                    //}

                    //if (!string.IsNullOrEmpty(Convert.ToString(row["Weight"])))
                    //{
                    //    currentWeight = double.Parse(Convert.ToString(row["Weight"]), CultureInfo.InvariantCulture);
                    //}
                    //if (!string.IsNullOrEmpty(Convert.ToString(row["IdentityNo"])))
                    //{
                    //   identityNo = Int32.Parse(Convert.ToString(row["IdentityNo"]), CultureInfo.InvariantCulture);
                    //}

                    //articles.Add(new LICSRequestArticle
                    //{
                    //    ArticleNo = (row["ArticleNo"] ?? string.Empty).ToString().Trim(),
                    //    ArticleNo2 = (row["ArticleNo2"] ?? string.Empty).ToString().Trim(),
                    //    ArticleDescription = (row["ArticleDescription"] ?? string.Empty).ToString().Trim(),
                    //    ArticleDescription2 = (row["ArticleDescription2"] ?? string.Empty).ToString().Trim(),
                    //    //  IdentityNo = identityNo,
                    //    QuantityUnit = (row["QuantityUnit"] ?? string.Empty).ToString().Trim(),
                    //    // EAN = (row["EAN"] ?? string.Empty).ToString(),
                    //    //  ProductCode = (row["ProductCode"] ?? string.Empty).ToString(),
                    //    //  ArticleGroup = (row["ArticleGroup"] ?? string.Empty).ToString(),
                    //    //  ArticleGroupFactor = currentArticleGroupFactor,
                    //    //   Weight = currentWeight
                    //});

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
                      //  string ind = column.ColumnName;
                        _loger.Log(string.Format("column.ColumnName ={0} value = {1}",(string)column.ColumnName,res.ToString()));
                        PropertyInfo propertyInfo = orderPosition.GetType().GetProperty(column.ColumnName);
                        _loger.Log("AFTER GETTING PROPERTY INFO");
                        if (propertyInfo==null)
                        {
                            _loger.Log(propertyInfo, "propertyInfo");
                            continue;
                        }

                        if (row[column.ColumnName].GetType().Equals(DBNull.Value.GetType()))
                        {
                            _loger.Log("VALUE IS NULL");
                            propertyInfo.SetValue(orderPosition, Convert.ChangeType(GetDefaultValue(propertyInfo.PropertyType), propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            _loger.Log("OKOKOKOKOKOKOKOKOK");
                            propertyInfo.SetValue(orderPosition, Convert.ChangeType(row[column.ColumnName].ToString().Trim(), propertyInfo.PropertyType), null);
                            //   propertyInfo.SetValue(orderPosition, Convert.ChangeType(row[column.ColumnName], propertyInfo.PropertyType), null);
                        }


                    }

                    orderPositions.Add(orderPosition);

                }
                catch (Exception ex)
                {
                    _loger.Log("Exception while reflect DataColumn values using Reflection in GetDeliveryPositions");
                    _loger.Log(ex);
                }

            }
            return orderPositions.ToArray();
        }

        private LICSRequestOrderRecipient GetOrderRecipient(SqlConnection connection, string referenceNo)
        {
        //    _loger.Log(_pluginSettings, "_pluginSettings");
       //     _loger.Log("_pluginSettings.OrderRecipientQuery" + _pluginSettings.OrderRecipientQuery);
            string getOrderRecipientQuery = string.Format(_pluginSettings.OrderRecipientQuery, referenceNo);
            SqlCommand cmd = new SqlCommand(getOrderRecipientQuery, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
      //      _loger.Log("Before reader");
            table.Load(reader);

            LICSRequestOrderRecipient orderRecipient = new LICSRequestOrderRecipient();
            foreach (DataRow row in table.Rows)
            {
        //        _loger.Log("COUNT OF TABLE ROWS = " + table.AsEnumerable().Count());
                try
                {


                    foreach (DataColumn column in row.Table.Columns)
                    {
                        var res = row[column.ColumnName];
             //           _loger.Log("RES = " + res);
                        PropertyInfo propertyInfo = orderRecipient.GetType().GetProperty(column.ColumnName);
             //           _loger.Log("column.ColumnName =" + column.ColumnName);
                        if(propertyInfo!=null)
                        {
            //                _loger.Log("propertyInfo VALIDITY" );
                        }
                        else
                        {
            //                _loger.Log(propertyInfo, "propertyInfo");
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
