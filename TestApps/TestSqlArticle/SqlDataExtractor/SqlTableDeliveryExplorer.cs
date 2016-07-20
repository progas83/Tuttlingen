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
  public class SqlTableDeliveryExplorer
    {
        public const string MsSqlDatabaseArticleTestConnectionString = @"Data Source =.\MSSQLIX4TEST;Initial Catalog = NavisionArticleTest; Integrated Security = True";
        public const string MsSqlDataTableRequestDelivery = "Ekkopf";

        private const string MsSqlDataTableDeliveryPositions = "Ekzeile";

        private string selectAllDeliveriesSql = @"SELECT Nr_ AS DeliveryNo,
                                                [Erwartetes Lieferdatum] AS DeliveryDate, 
                                                Lagerortcode AS DeliveryArea, 
                                                Spediteur AS DeliveryPlace,
                                                Buchungsdatum AS OrderDate
                                        FROM Ekkopf";

        private string selectAllDeliveryPositionsSql = @"SELECT Zeilennr_ AS PositionNo,
                                                            [Kred_-Artikelnr_] AS ReferenceNo, 
                                                            Belegnr_ ,
                                                            Nr_ AS ArticleNo, 
                                                            [VPE Art] AS ArticleGroup,
                                                            [Versandart (Palette)] AS LoadType,
                                                            [Versandart (Palette) Anzahl] AS TargetLoadsCount,
                                                            [VPE Anzahl] AS TargetQuantity,
                                                            Buchungsgruppe AS ProjectNo,
                                                            Beschreibung AS Comment
                                                        FROM Ekzeile WHERE Belegnr_ = '{0}'";// equals {Nr_ from Ekkopf}";


        //WHERE Belegnr_ equals {Nr_ from Ekkopf} 


        public void GetArticles()
        {
            try
            {
                using (var connection = new SqlConnection(MsSqlDatabaseArticleTestConnectionString))
                {
                    connection.Open();
                    var cmdText = selectAllDeliveriesSql;
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var res = LoadDeliveries(reader, connection);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private LICSRequestDelivery[] LoadDeliveries(IDataReader reader, SqlConnection connection)
        {
            DataTable table = new DataTable();
            List<LICSRequestDelivery> deliveries = new List<LICSRequestDelivery>();
            try
            {
                table.Load(reader);
                foreach (DataRow row in table.AsEnumerable())
                {

                    //var re = row["DeliveryNo"];
                    //var re2 = row["DeliveryDate"];
                   
                    //var re3 = row["DeliveryArea"];
                    //var re4 = row["DeliveryPlace"];
                    //var re5 = row["OrderDate"];
                    
                    //DateTime D1eleiveryDate = DateTime.Parse(row["DeliveryDate"].ToString());

                    string deliveryNo = (row["DeliveryNo"] ?? string.Empty).ToString();

                    DateTime deliveryDate;
                    if (!DateTime.TryParse(row["DeliveryDate"].ToString(), out deliveryDate))
                    {

                    }

                    DateTime orderDate;
                    if (!DateTime.TryParse(row["OrderDate"].ToString(), out orderDate))
                    {

                    }
                    LICSRequestDelivery delivery = new LICSRequestDelivery
                    {
                        DeliveryNo = deliveryNo,
                        DeliveryDate = deliveryDate,//DateTime.Parse(row["DeliveryDate"].ToString()), // DateTime.ParseExact((row["DeliveryDate"] ?? string.Empty).ToString(), "dd.MM.yy", System.Globalization.CultureInfo.InvariantCulture),//.Parse(navisionOutputPayload.OrderHeader.Date); // STRONG TYPIZATION!!!!
                        DeliveryArea = (row["DeliveryArea"] ?? string.Empty).ToString(),
                        DeliveryPlace = (row["DeliveryPlace"] ?? string.Empty).ToString(),
                        OrderDate = orderDate// DateTime.Parse(row["OrderDate"].ToString()) // DateTime.ParseExact((row["OrderDate"] ?? DateTime.Now).ToString(), "dd.MM.yy", System.Globalization.CultureInfo.InvariantCulture)
                    };

                    delivery.Positions = GetDeliveryPositions(connection, deliveryNo);
                    deliveries.Add(delivery);
                }
            }
            catch (Exception ex)
            {

            }
            return deliveries.ToArray();
        }

        private LICSRequestDeliveryPosition[] GetDeliveryPositions(SqlConnection connection, string deliveryNo)
        {
            List<LICSRequestDeliveryPosition> deliveryPositions = new List<LICSRequestDeliveryPosition>();

            string getPositionsCommand = string.Format(selectAllDeliveryPositionsSql,deliveryNo);
            SqlCommand cmd = new SqlCommand(getPositionsCommand, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            foreach (DataRow row in table.AsEnumerable())
            {
                //var re = row["PositionNo"];
                //var re2 = row["ReferenceNo"];
                //var re3 = row["ArticleNo"];
                //var re4 = row["ArticleGroup"];
                //var re5 = row["TargetLoadsCount"];
                //var re6 = row["TargetQuantity"];
                //var re8 = row["ProjectNo"];
                //var r34 = row["Comment"];

                int positionNo = 0;
                if(!string.IsNullOrEmpty(Convert.ToString(row["PositionNo"])))
                {
                    positionNo = Int32.Parse(Convert.ToString(row["PositionNo"]));
                }
                //int targetLoadsCount = 0;
                //if (!string.IsNullOrEmpty(Convert.ToString(row["TargetLoadsCount"])))
                //{
                //    targetLoadsCount = Int32.Parse(Convert.ToString(row["TargetLoadsCount"]));
                //}
                double targetQuantity = 0;
                if (!string.IsNullOrEmpty(Convert.ToString(row["TargetQuantity"])))
                {
                    targetQuantity = double.Parse(Convert.ToString(row["TargetQuantity"]), CultureInfo.InvariantCulture);
                }

                deliveryPositions.Add(new LICSRequestDeliveryPosition
                {
                    PositionNo = positionNo,
                    ReferenceNo = (row["ReferenceNo"] ?? string.Empty).ToString(),
                    ArticleNo = (row["ArticleNo"] ?? string.Empty).ToString(),
                    //EAN = (row["EAN"] ?? string.Empty).ToString(),
                    ArticleGroup = (row["ArticleGroup"] ?? string.Empty).ToString(),
                    //  LoadType = (row["LoadType"] ?? string.Empty).ToString(),
                   // TargetLoadsCount = targetLoadsCount,  !!! Double to int Wrong mapping
                    //ArticlePerLoad = (row["ArticlePerLoad"] ?? string.Empty).ToString(),
                    TargetQuantity = targetQuantity,
                    //Charge = (row["Charge"] ?? string.Empty).ToString(),
                    //SerialNo = (row["SerialNo"] ?? string.Empty).ToString(),
                    //ExpiryDate = (row["ExpiryDate"] ?? string.Empty).ToString(),
                    ProjectNo = (row["ProjectNo"] ?? string.Empty).ToString(),
                    //SSCC = (row["SSCC"] ?? string.Empty).ToString(),
                    Comment = (row["Comment"] ?? string.Empty).ToString()
                });
            }


            return deliveryPositions.ToArray();
        }

        //private IEnumerable<LICSRequestArticle> LoadArticles(IDataReader reader)
        //{
        //    DataTable table = new DataTable();
        //    List<LICSRequestArticle> articles = new List<LICSRequestArticle>();
        //    try
        //    {
        //        table.Load(reader);
        //        foreach (DataRow row in table.AsEnumerable())
        //        {

        //            var re = row["ArticleNo"];
        //            var re2 = row["ArticleNo2"];
        //            var re3 = row["ArticleDescription"];
        //            var re4 = row["ArticleDescription2"];
        //            var re5 = row["EAN"];
        //            var re6 = row["ProductCode"];
        //            var re8 = row["ArticleGroup"];
        //            var r34 = row["ArticleGroupFactor"];
        //            var re7 = row["Weight"];
        //            var re71 = row["Weight"];
        //            var re72 = row["Weight"];
        //            var re73 = row["Weight"];
        //            var re74 = row["Weight"];
        //            var str = Convert.ToString(row["Weight"]);


        //            double currentArticleGroupFactor = 0;
        //            if (!string.IsNullOrEmpty(Convert.ToString(row["ArticleGroupFactor"])))
        //            {
        //                currentArticleGroupFactor = double.Parse(Convert.ToString(row["ArticleGroupFactor"]), CultureInfo.InvariantCulture);
        //            }
        //            double currentWeight = 0;
        //            if (!string.IsNullOrEmpty(Convert.ToString(row["Weight"])))
        //            {
        //                currentWeight = double.Parse(Convert.ToString(row["Weight"]), CultureInfo.InvariantCulture);
        //            }
        //            articles.Add(new LICSRequestArticle
        //            {
        //                ArticleNo = (row["ArticleNo"] ?? string.Empty).ToString(),
        //                ArticleNo2 = (row["ArticleNo2"] ?? string.Empty).ToString(),
        //                ArticleDescription = (row["ArticleDescription"] ?? string.Empty).ToString(),
        //                ArticleDescription2 = (row["ArticleDescription2"] ?? string.Empty).ToString(),
        //                EAN = (row["EAN"] ?? string.Empty).ToString(),
        //                ProductCode = (row["ProductCode"] ?? string.Empty).ToString(),
        //                ArticleGroup = (row["ArticleGroup"] ?? string.Empty).ToString(),
        //                ArticleGroupFactor = currentArticleGroupFactor,// Convert.ToDouble(row["ArticleGroupFactor"] ?? 0),
        //                Weight = currentWeight// double.Parse(Convert.ToString((row["Weight"] ?? string.Empty)), CultureInfo.InvariantCulture)
        //                //  Weight = Convert.ToDouble(row["Weight"] ?? 0)                         Convert.ToString((row["Weight"] ?? string.Empty))
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return articles.Where(i => !string.IsNullOrEmpty(i.ArticleNo));
        //}

    }
}
