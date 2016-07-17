using Ix4Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CsvDataExtractor
{
    [Export(typeof(ICustomerDataConnector))]
    [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CustomDataSourceTypes.Csv)]
    // [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.ServiceName)]
    // [ExportMetadata(CurrentServiceInformation.NameForPluginDataSourceType, CurrentServiceInformation.CustomDataSourceTypeCsv)]
    public class CsvCustomerDataExtractor : ICustomerDataConnector
    {
        public UserControl GetControlForSettings()
        {
            throw new NotImplementedException();
        }

        public string GetCustomerData()
        {
            throw new NotImplementedException();
            //LICSRequest lre = new LICSRequest();
            
            
        }

        public LICSRequest GetCustomerDataFromXml(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
