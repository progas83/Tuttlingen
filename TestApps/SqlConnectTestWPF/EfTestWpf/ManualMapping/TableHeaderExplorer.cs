using Ix4Modes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfTestWpf.ManualMapping
{
  public  class TableHeaderExplorer
    {
        private string _connectionString;
        public TableHeaderExplorer(string connectionString)
        {
            _connectionString = connectionString;
        }
        private string selectAllSql = "SELECT * FROM {0}";
        public List<DataSourceInfo> GetTabelHeader(string tableName)
        {
            List<DataSourceInfo> resultList = new List<DataSourceInfo>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmdText = string.Format(selectAllSql, tableName);
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                var schemaTable = reader.GetSchemaTable();
                foreach (DataRowView row in schemaTable.DefaultView)
                {
                    var r = row["DataTypeName"].ToString();
                  

                    //   var re = typeof(r);
                  //  Type t =(Type) r["Name"];
                    resultList.Add(new DataSourceInfo((string)row["ColumnName"], (Type)row["DataType"]));
                }

            }
            return resultList;
        }
    }
}
