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
        public static string ServiceName { get { return _serviceName; } }

        public static string ServiceDescription { get { return _serviceDescription; } }
    }
}
