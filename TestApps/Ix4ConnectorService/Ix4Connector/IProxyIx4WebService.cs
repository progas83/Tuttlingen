using Ix4Connector.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ix4Connector
{
   public interface IProxyIx4WebService
    {
        string ImportXmlRequest(byte[] xmlFile, string fileName);
        XmlNode ExportData(string exportDataType, string[] additionalParameters);
        void ExportDataAsync(string exportDataType, string[] additionalParameters);

        event ExportDataAsyncCompletedEventHandler ExportDataAsyncCompleted;
    }
}
