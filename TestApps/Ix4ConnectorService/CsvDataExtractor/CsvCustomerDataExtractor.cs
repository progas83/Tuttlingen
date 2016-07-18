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
    [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.CustomDataSourceTypeCsv)]
    // [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.ServiceName)]
    // [ExportMetadata(CurrentServiceInformation.NameForPluginDataSourceType, CurrentServiceInformation.CustomDataSourceTypeCsv)]
    public class CsvCustomerDataExtractor : ICustomerDataConnector
    {
        public UserControl GetControlForSettings()
        {
            return new UserControl() { Content = new Label() { Content = "I am no implemented user control Of CSV DaTA" } };
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
