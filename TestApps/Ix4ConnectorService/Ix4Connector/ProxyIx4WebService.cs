using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Ix4Connector.Args;
using Ix4Connector.Ix4WebService;

namespace Ix4Connector
{
    internal class ProxyIx4WebService : IProxyIx4WebService
    {
        private LBSoapAuthenticationHeader _header;

        public ProxyIx4WebService(LBSoapAuthenticationHeader header)
        {
            this._header = header;
        }

        public event ExportDataAsyncCompletedEventHandler ExportDataAsyncCompleted;

        public XmlNode ExportData(string exportDataType, string[] additionalParameters)
        {
            throw new NotImplementedException();
        }

        public void ExportDataAsync(string exportDataType, string[] additionalParameters)
        {
            throw new NotImplementedException();
        }

        public string ImportXmlRequest(byte[] xmlFile, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
