using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class CurrentServiceInformation
    {
        private static readonly string _serviceName = "NavisionService";// to ix4 connector";
        public static string ServiceName { get { return _serviceName; } }
    }
}
