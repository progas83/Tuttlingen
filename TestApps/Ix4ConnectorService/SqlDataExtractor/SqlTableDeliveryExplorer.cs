using Ix4Models;
using Ix4Models.Interfaces;
using Ix4Models.SettingsDataModel;
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
        private MsSqlPluginSettings _pluginSettings;
        public SqlTableDeliveryExplorer(IPluginSettings pluginSettings)
        {
            _pluginSettings = pluginSettings as MsSqlPluginSettings;
        }
      //  public const string MsSqlDatabaseArticleTestConnectionString = @"Data Source =.\MSSQLIX4TEST;Initial Catalog = NavisionArticleTest; Integrated Security = True";
      //  public const string MsSqlDataTableRequestDelivery = "Ekkopf";

      //  private const string MsSqlDataTableDeliveryPositions = "Ekzeile";

     //   private string selectAllDeliveriesSql = @"SELECT Nr_ AS DeliveryNo, [Erwartetes Lieferdatum] AS DeliveryDate, Lagerortcode AS DeliveryArea, Spediteur AS DeliveryPlace, Buchungsdatum AS OrderDate FROM Ekkopf";

     //   private string selectAllDeliveryPositionsSql = @"SELECT Zeilennr_ AS PositionNo, [Kred_-Artikelnr_] AS ReferenceNo, Belegnr_ , Nr_ AS ArticleNo, [VPE Art] AS ArticleGroup, [Versandart (Palette)] AS LoadType, [Versandart (Palette) Anzahl] AS TargetLoadsCount, [VPE Anzahl] AS TargetQuantity, Buchungsgruppe AS ProjectNo, Beschreibung AS Comment FROM Ekzeile WHERE Belegnr_ = '{0}'";// equals {Nr_ from Ekkopf}";

        private string DbConnection
        {
            get
            {
                return string.Format(CurrentServiceInformation.MsSqlDatabaseArticleTestConnectionString, _pluginSettings.DbSettings.ServerAdress, _pluginSettings.DbSettings.DataBaseName);
            }
        }
        public LICSRequestDelivery[] GetRequestDeliveries()
        {
            LICSRequestDelivery[] requestDeliveries = new LICSRequestDelivery[] { };
            try
            {
                using (var connection = new SqlConnection(DbConnection))
                {
                    connection.Open();
                    var cmdText = _pluginSettings.DeliveriesQuery;
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    requestDeliveries = LoadDeliveries(reader, connection);
                }
            }
            catch (Exception ex)
            {

            }
            return requestDeliveries;
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
                        DeliveryDate = deliveryDate,
                        DeliveryArea = (row["DeliveryArea"] ?? string.Empty).ToString(),
                        DeliveryPlace = (row["DeliveryPlace"] ?? string.Empty).ToString(),
                        OrderDate = orderDate
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

            string getPositionsCommand = string.Format(_pluginSettings.PositionsQuery, deliveryNo);
            SqlCommand cmd = new SqlCommand(getPositionsCommand, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            foreach (DataRow row in table.AsEnumerable())
            {
                int positionNo = 0;
                if (!string.IsNullOrEmpty(Convert.ToString(row["PositionNo"])))
                {
                    positionNo = Int32.Parse(Convert.ToString(row["PositionNo"]));
                }

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
    }
}
