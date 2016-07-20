using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataExtractor
{
    public class SqlTableArticleExplorer
    {

        public const string MsSqlDatabaseArticleTestConnectionString = @"Data Source =.\MSSQLIX4TEST;Initial Catalog = NavisionArticleTest; Integrated Security = True";
        public const string MsSqlDataTableArticlesName = "ArticlesExport";


     //   private string _connectionString;
        public  SqlTableArticleExplorer()// string connectionString)
        {
           // _connectionString = connectionString;
        }
        private string selectAllArticlesSql = @"SELECT Nr_ AS ArticleNo,
                                                [Nummer 2] AS ArticleNo2, 
                                                Beschreibung AS ArticleDescription, 
                                                [Beschreibung 2] AS ArticleDescription2,
                                                [EAN VPE] AS EAN,
                                                Basiseinheitencode AS ProductCode,
                                                Artikelgruppe AS ArticleGroup,
                                                Stammnummer AS ArticleGroupFactor,
                                                [VPE Gewicht] AS Weight
                                        FROM ArticlesExport";
        public void GetArticles()
        {
            try
            {
                using (var connection = new SqlConnection(MsSqlDatabaseArticleTestConnectionString))
                {
                    connection.Open();
                    var cmdText = selectAllArticlesSql;
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var res = LoadArticles(reader);
                }
            }
            catch(Exception ex)
            {

            }
        }
        private IEnumerable<LICSRequestArticle> LoadArticles(IDataReader reader)
        {
            DataTable table = new DataTable();
            List<LICSRequestArticle> articles = new List<LICSRequestArticle>();
            try
            {
                table.Load(reader);
                foreach (DataRow row in table.AsEnumerable())
                {

                    var re = row["ArticleNo"];
                    var re2 = row["ArticleNo2"];
                    var re3 = row["ArticleDescription"];
                    var re4 = row["ArticleDescription2"];
                    var re5 = row["EAN"];
                    var re6 = row["ProductCode"];
                    var re8 = row["ArticleGroup"];
                    var r34 = row["ArticleGroupFactor"];
                    var re7 = row["Weight"];
                    var re71 = row["Weight"];
                    var re72 = row["Weight"];
                    var re73 = row["Weight"];
                    var re74 = row["Weight"];
                    var str = Convert.ToString(row["Weight"]);


                    double currentArticleGroupFactor = 0;
                    if (!string.IsNullOrEmpty(Convert.ToString(row["ArticleGroupFactor"])))
                    {
                        currentArticleGroupFactor = double.Parse(Convert.ToString(row["ArticleGroupFactor"]), CultureInfo.InvariantCulture);
                    }
                    double currentWeight = 0;
                    if (!string.IsNullOrEmpty(Convert.ToString(row["Weight"])))
                    {
                        currentWeight = double.Parse(Convert.ToString(row["Weight"]), CultureInfo.InvariantCulture);
                    }
                    articles.Add(new LICSRequestArticle
                    {
                        ArticleNo = (row["ArticleNo"] ?? string.Empty).ToString(),
                        ArticleNo2 = (row["ArticleNo2"] ?? string.Empty).ToString(),
                        ArticleDescription = (row["ArticleDescription"] ?? string.Empty).ToString(),
                        ArticleDescription2 = (row["ArticleDescription2"] ?? string.Empty).ToString(),
                        EAN = (row["EAN"] ?? string.Empty).ToString(),
                        ProductCode = (row["ProductCode"] ?? string.Empty).ToString(),
                        ArticleGroup = (row["ArticleGroup"] ?? string.Empty).ToString(),
                        ArticleGroupFactor = currentArticleGroupFactor,// Convert.ToDouble(row["ArticleGroupFactor"] ?? 0),
                        Weight = currentWeight// double.Parse(Convert.ToString((row["Weight"] ?? string.Empty)), CultureInfo.InvariantCulture)
                        //  Weight = Convert.ToDouble(row["Weight"] ?? 0)                         Convert.ToString((row["Weight"] ?? string.Empty))
                    });
                }
            }
            catch (Exception ex)
            {
                
            }
            return articles.Where(i => !string.IsNullOrEmpty(i.ArticleNo));
        }
        //private IEnumerable<LICSRequestArticle> ConvertTableToArticles(DataTable table)
        //{
        //    List<LICSRequestArticle> articles = new List<LICSRequestArticle>();
        //    EnumerableRowCollection<DataRow> rows = table.AsEnumerable();
        //    foreach(DataRow row in rows)
        //    {

        //        var re = row["ArticleNo"];
        //        var re2 = row["ArticleNo2"];
        //        var re3 = row["ArticleDescription"];
        //        var re4 = row["ArticleDescription2"];
        //        articles.Add(new LICSRequestArticle
        //        {
        //            ArticleNo = row["ArticleNo"].ToString(),
        //            ArticleNo2 = row["ArticleNo2"].ToString(),
        //            ArticleDescription = row["ArticleDescription"].ToString(),
        //            ArticleDescription2 = row["ArticleDescription2"].ToString()
        //        });
        //        // var re = row["ArticleNo"];
        //        // var re2 = row["ArticleNo2"];
        //    }
        //    return articles.Where(i => !string.IsNullOrEmpty(i.ArticleNo));
        //    //return table.AsEnumerable().Select(dataItem => new LICSRequestArticle
        //    //{
        //    //    ArticleNo = dataItem["ArticleNo"].ToString(),
        //    //    ArticleNo2 = dataItem["ArticleNo2"].ToString(),
        //    //    ArticleDescription = dataItem["ArticleDescription"].ToString(),
        //    //    ArticleDescription2 = dataItem["ArticleDescription2"].ToString()
        //    //});
        //}

        //private DataTable Load(IDataReader reader)
        //{
        //    DataTable table = new DataTable();
        //   // DataView dataView = new DataView();
        //    try
        //    {
        //        table.Columns.Clear();
        //        //var schemaTable = reader.GetSchemaTable();
        //        //foreach (DataRowView row in schemaTable.DefaultView)
        //        //{
        //        //    var columnName = (string)row["ColumnName"];
        //        //    var type = (Type)row["DataType"];
        //        //    table.Columns.Add(columnName, type);
        //        //}

        //        table.Load(reader);
        //     //   dataView = table.DefaultView;
        //    }
        //    catch (Exception ex)
        //    {
        //       // Logger.Instance.Logging(LogStatus.Error, ex.Message);
        //    }

        //    return table;
        //}
    }
}
