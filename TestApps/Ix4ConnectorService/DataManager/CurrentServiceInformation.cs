using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class CurrentServiceInformation
    {
        private static readonly string _serviceName = "Navision to ix4 connector";
        private static readonly string _serviceDescription = "Navitel to ix4 adapter service";
        public const string ServiceName = "Navision to ix4 connector";// { get { return _serviceName; } }

        public static string ServiceDescription { get { return _serviceDescription; } }

        public const string NameForPluginMetadata = "ConnectorMetadata";

        public const string PluginsSubdirectory = "Plugins";
    }
}
