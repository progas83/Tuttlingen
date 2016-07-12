using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4ServiceConfigurator.Model
{
    [Serializable]
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            ServiceName = DataManager.CurrentServiceInformation.ServiceName;
        }

        public string ServiceName { get; set; }
        public string UserName { get; set; }

        public int ClientID { get; set; }

        public string Password { get; set; }
        public string ServiceEndpoint { get; set; }

        public bool Default { get; set; }
    }
}
