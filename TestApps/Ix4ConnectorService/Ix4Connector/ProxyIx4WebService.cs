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
            return GetWebPublicInterface().ExportData(exportDataType, additionalParameters);
        }

        public void ExportDataAsync(string exportDataType, string[] additionalParameters)
        {
            Ix4WebService.ix4PublicInterface ws = GetWebPublicInterface();
            ws.ExportDataCompleted += OnExportDataAsyncCompleted;
            ws.ExportDataAsync(exportDataType, additionalParameters);
        }

        private void OnExportDataAsyncCompleted(object sender, ExportDataCompletedEventArgs e)
        {
            if(ExportDataAsyncCompleted!=null)
            {
                ExportDataAsyncCompleted(sender, new ExportDataAsyncCompletedEventArgs(e));
            }
        }

        public string ImportXmlRequest(byte[] xmlFile, string fileName)
        {
            throw new NotImplementedException();
        }

        private Ix4WebService.ix4PublicInterface GetWebPublicInterface()
        {
            Ix4WebService.ix4PublicInterface ws = new Ix4WebService.ix4PublicInterface();
            ws.LBSoapAuthenticationHeaderValue = _header;
            return ws;
        }
    }
}
