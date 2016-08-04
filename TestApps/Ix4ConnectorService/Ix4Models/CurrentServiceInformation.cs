using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Models
{
    public class CurrentServiceInformation
    {
        // private static readonly string _serviceName = "Navision to ix4 connector";

        // remote db connection server=sip1.skypro.eu;database=GWTalkDB;userid=UserReadDB;password=Asdf1234;Allow User Variables=True

        private static readonly string _serviceDescription = "Navitel to ix4 adapter service";
        public const string ServiceName = "Ix4-Agent";// { get { return _serviceName; } }

        public static string ServiceDescription { get { return _serviceDescription; } }

        public const string NameForPluginMetadata = "ConnectorMetadata";

        public const string PluginsSubdirectory = "Plugins";
        public const string NameForPluginDataSourceType = "DataSourceTypeMetadata";

     //   public const string MsSqlDatabaseConnectionString = @"Data Source =.\MSSQLIX4TEST;Initial Catalog = IlyaTest; Integrated Security = True";
        public const string MsSqlDataTableName = "Chips";

        

        public const string CustomDataSourceTypeMsSql = "MsSql";
        public const string CustomDataSourceTypeCsv = "Csv";
        public const string CustomDataSourceTypeXml = "Xml";
       // =myServerAddress;Database=myDataBase;Trusted_Connection=True;
        public const string MsSqlDatabaseConnectionStringWindowsAuth = @"Data Source ={0};Initial Catalog = {1}; Integrated Security = True";
        public const string MsSqlDatabaseConnectionStringWithServerAuth = @"Server={0}; Database = {1}; User Id= {2}; Password={3};";

        private static readonly string _xmlFileName = string.Format("{0}{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "\\configuration.xml");// @"C:\Ilya\ServiceProgram\configuration.xml";// "configuration.xml";
        public static string FileName { get { return _xmlFileName; } }

        private static readonly string _loggerFileName = string.Format("{0}{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "\\logger.log");// @"C:\Ilya\ServiceProgram\configuration.xml";// "configuration.xml";
        public static string LoggerFileName { get { return _loggerFileName; } }

    }
}
