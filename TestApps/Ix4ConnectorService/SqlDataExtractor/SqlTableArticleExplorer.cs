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

        public SqlTableArticleExplorer()
        {
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
        public LICSRequestArticle[] GetArticles()
        {
            LICSRequestArticle[] articles = null;
            try
            {
                using (var connection = new SqlConnection(MsSqlDatabaseArticleTestConnectionString))
                {
                    connection.Open();
                    var cmdText = selectAllArticlesSql;
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    articles = LoadArticles(reader);
                }
            }
            catch (Exception ex)
            {

            }
            return articles;
        }
        private LICSRequestArticle[] LoadArticles(IDataReader reader)
        {
            DataTable table = new DataTable();
            List<LICSRequestArticle> articles = new List<LICSRequestArticle>();
            try
            {
                table.Load(reader);
                foreach (DataRow row in table.AsEnumerable())
                {
                    double currentArticleGroupFactor = 0;
                    double currentWeight = 0;
                    if (!string.IsNullOrEmpty(Convert.ToString(row["ArticleGroupFactor"])))
                    {
                        currentArticleGroupFactor = double.Parse(Convert.ToString(row["ArticleGroupFactor"]), CultureInfo.InvariantCulture);
                    }
                   
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
                        ArticleGroupFactor = currentArticleGroupFactor,
                        Weight = currentWeight
                    });
                }
            }
            catch (Exception ex)
            {

            }
            return articles.Where(i => !string.IsNullOrEmpty(i.ArticleNo)).ToArray();
        }
    }
}
