using Ix4Models.Interfaces;
using Ix4Models.Schema.WV;
using Ix4Models.SettingsDataModel;
using SimplestLogger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SqlDataExtractor
{
    class ExportDataToSQL : SqlTableWorker
    {
        public ExportDataToSQL(IPluginSettings pluginSettings) : base(pluginSettings)
        {

        }

        //  internal void SaveDataToTable(string dataInstance, string exportData)
        //  {
        //      // Stream sr = new FileStream(, FileMode.Open);

        //    //  XmlNode node = new XmlNode();

        //      XmlDocument doc = new XmlDocument();
        //      doc.LoadXml(exportData);

        //     // MSG content = 
        //      XmlSerializer serializer = new XmlSerializer(typeof(MSG));
        //      using (FileStream fs = new FileStream(@"E:\Ilya\WV_Info\WW_LMS\WW_LMS\GSMSG.xml", FileMode.Open))
        //      {
        //          MSG res = (MSG)serializer.Deserialize(fs);
        //      }

        //      //TextReader reader = new StringReader(exportData);
        //      //var res = (NewDataSet)serializer.Deserialize(reader);
        ////      NewDataSet wvExportData = new NewDataSet();

        //  }

        internal void SaveDataToTable(XmlNode exportData)
        {
            XmlNodeList msgNodes = exportData.LastChild.LastChild.SelectNodes("MSG");
            if (msgNodes.Count > 0)
            {
                _loger.Log(string.Format("Export data count = {0}", msgNodes.Count));
                XmlSerializer sr = new XmlSerializer(typeof(MSG));

                foreach (XmlNode node in msgNodes)
                {
                    try
                    {
                        TextReader tr = new StringReader(node.OuterXml);
                        MSG red = (MSG)sr.Deserialize(tr);
                        if(red.WAKopfID == 1680191 || red.WAKopfID ==  1680198)
                        {
                            InsertIntoTable(red);
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        _loger.Log(ex);
                    }
                  
                }

            }
        }
      //  private string _dbConnection = @"Data Source=192.168.50.3\sql,1433;Network Library=DBMSSOCN;Initial Catalog=InterfaceDilosLMS; User ID=sa;Password=sa";
        
        private string _dbConnection = @"Data Source =DESKTOP-PC\SQLEXPRESS2012;Initial Catalog = InterfaceDilosLMS;Integrated Security=SSPI";
        private void InsertIntoTable(MSG message)
        {
          using (var connection = new SqlConnection(_dbConnection))
            {
              //  connection.Open();
                
                int headerID = InsertHeader(message,connection);
                SqlCommand cmd = InsertPosition("MsgPos", message, headerID);
                cmd.Connection = connection;
                connection.Open();
                _loger.Log("Connection opened to InterfaceDilosLMS for InsertPosition");
                var result = cmd.ExecuteNonQuery();
                //var cmdText = _pluginSettings.OrdersQuery;
               // SqlCommand cmd = new SqlCommand(cmdText, connection);
                //SqlDataReader reader = cmd.ExecuteReader();
                //orders = LoadOrders(reader, connection);
                _loger.Log(string.Format("SQL commang affected {0} rows", result));
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        private  SqlCommand InsertPosition(string tabelName, MSG message, int headerID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            StringBuilder tableColumnsNames = new StringBuilder();
            StringBuilder commandParametersNames = new StringBuilder();
            try
            {
                tableColumnsNames.Append("HeaderID");
                commandParametersNames.Append("@posHeaderID");
                sqlCommand.Parameters.AddWithValue("@posHeaderID", headerID);

                PropertyInfo[] posProperties = message.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(MSGPosAttribute))).ToArray();

                for (int i = 0; i < posProperties.Length; i++)// PropertyInfo prop in posProperties)
                {
                    if (posProperties[i].GetValue(message) != null)
                    {
                        tableColumnsNames.Append(",");
                        tableColumnsNames.Append(posProperties[i].Name);

                        commandParametersNames.Append(",");
                        string posItem = string.Format("@pos{0}", posProperties[i].Name);
                        commandParametersNames.Append(posItem);
                        sqlCommand.Parameters.AddWithValue(posItem, posProperties[i].GetValue(message));
                    }
                }

                string commandText = string.Format(@"INSERT INTO {0} ({1}) VALUES({2})", tabelName, tableColumnsNames.ToString(), commandParametersNames.ToString());
                _loger.Log(string.Format("Insert position command = {0}", commandText));
                sqlCommand.CommandText = commandText;
            }
            catch(Exception ex)
            {
                _loger.Log(ex);
            }
            return sqlCommand;
        }

        private int InsertHeader(MSG message, SqlConnection con)
        {                                                                                           // output INSERTED.ID
            int modified = -1;
            //using (SqlCommand cmd = new SqlCommand("INSERT INTO MsgHeader (Type,Status,[User], Created,LastUpdate,ErrorText) VALUES (@hType,@hStatus,@hUser,@hCreated,@hLastUpdate,@hErrorText);", con))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO MsgHeader (Type,Status,[User], Created,LastUpdate,ErrorText) output INSERTED.ID VALUES (@hType,@hStatus,@hUser,@hCreated,@hLastUpdate,@hErrorText);", con))
            {
                cmd.Parameters.AddWithValue("@hType", message.Type);
            
                cmd.Parameters.AddWithValue("@hStatus", message.Status);
                cmd.Parameters.AddWithValue("@hUser", message.User);
                cmd.Parameters.AddWithValue("@hCreated",message.Created);
                cmd.Parameters.AddWithValue("@hLastUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@hErrorText", string.IsNullOrEmpty(message.ErrorText) ? string.Empty : message.ErrorText);



                con.Open();
                _loger.Log("Connection opened to InterfaceDilosLMS for InsertHeader");
                try
                {
                    modified = (int)cmd.ExecuteScalar();
                }
                catch(Exception ex)
                {

                }
                
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

                return modified;
            }
        }

        private string GetTableName(string msgType)
        {
            string result = string.Empty;
            switch (msgType)
            {
                case "GR":
                    break;
                case "GP":
                    break;
                case "GS":
                    break;
                case "CA":
                    break;
                case "BO":
                    break;
                case "SA":
                    break;

                default:
                    break;
            }
            return result;
        }
        // „InterfaceDilosLMS“ – the tables „Msgheader“ and „Msgpos“.
        //         “GR” Goods Received
        //-          “GP” Goods Picked
        //-          “GS” Goods Shipped
        //-          “CA” Cancel Order
        //-          “BO” Stock corrections/adjustmets
        //-          “SA” Stock
        //    using(SqlCommand cmd = new SqlCommand("INSERT INTO Mem_Basic(Mem_Na,Mem_Occ) output INSERTED.ID VALUES(@na,@occ)", con))
        //{
        //    cmd.Parameters.AddWithValue("@na", Mem_NA);
        //    cmd.Parameters.AddWithValue("@occ", Mem_Occ);
        //    con.Open();

        //    int modified = (int)cmd.ExecuteScalar();

        //    if (con.State == System.Data.ConnectionState.Open) 
        //        con.Close();

        //    return modified;
        //}
    }
}
