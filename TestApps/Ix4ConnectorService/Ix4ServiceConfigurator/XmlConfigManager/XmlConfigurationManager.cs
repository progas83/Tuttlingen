using Ix4ServiceConfigurator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ix4ServiceConfigurator.XmlConfigManager
{
    public class XmlConfigurationManager
    {
        private static object _padlock = new object();
        private XmlSerializer _xmlSerializer;
        private static XmlConfigurationManager _configrator = null;
        private XmlConfigurationManager()
        {
            _xmlSerializer = new XmlSerializer(typeof(CustomerInfo));
        }
        public static XmlConfigurationManager Instance
        {
            get
            {
                if (_configrator == null)
                {
                    lock (_padlock)
                    {
                        if (_configrator == null)
                        {
                            _configrator = new XmlConfigurationManager();
                        }
                    }
                }

                return _configrator;
            }
        }

        public CustomerInfo GetCustomerInformation()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (FileStream fs = new FileStream(DataManager.XmlFileData.FileName, FileMode.OpenOrCreate))
                {
                    customerInfo = (CustomerInfo)_xmlSerializer.Deserialize(fs);
                }
            }
            catch
            {

            }

            return customerInfo;
        }

        public void UpdateCustomerInformation(CustomerInfo customerInfo)
        {
            try
            {
                using (FileStream fs = new FileStream(DataManager.XmlFileData.FileName, FileMode.OpenOrCreate))
                {
                    _xmlSerializer.Serialize(fs, customerInfo);
                }
            }
            catch
            {

            }

        }
    }
}
