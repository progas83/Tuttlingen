using Ix4Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace XmlDataExtractor
{
    [Export(typeof(ICustomerDataConnector))]
    [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CustomDataSourceTypes.Xml)]
    //  [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.ServiceName)]
    //  [ExportMetadata(CurrentServiceInformation.NameForPluginDataSourceType, CustomDataSourceTypes.Xml)]
    public class XmlDataExtractor : ICustomerDataConnector
    {
        public UserControl GetControlForSettings()
        {
            throw new NotImplementedException();
        }

        public string GetCustomerData()
        {
            throw new NotImplementedException();
        }

        public LICSRequest GetCustomerDataFromXml(string fileName)
        {

            XmlSerializer xS = new XmlSerializer(typeof(OutputPayLoad));
            LICSRequest licsRequest = new LICSRequest();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
            
                OutputPayLoad customerInfo =(OutputPayLoad) xS.Deserialize(fs);
            }

            return licsRequest;
        }
    }
}
