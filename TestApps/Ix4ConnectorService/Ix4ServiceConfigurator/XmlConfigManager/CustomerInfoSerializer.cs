using CryptoModule;
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
   public class CustomerInfoSerializer : XmlSerializer
    {
        private Cryptor _cryptor;
        public CustomerInfoSerializer() : base(typeof(CustomerInfo))
        {
            _cryptor = new Cryptor();
            
        }

        public CustomerInfo Deserialize(FileStream fs)
        {
            CustomerInfo customerInfo = (CustomerInfo)base.Deserialize(fs);
            customerInfo.Decrypt(_cryptor);
            return customerInfo;
        }

        public void Serialize(FileStream fs, CustomerInfo customerInfo)
        {
            customerInfo.Encrypt(_cryptor);
            base.Serialize(fs, customerInfo);
        }
      
    }
}
