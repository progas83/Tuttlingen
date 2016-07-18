using Ix4Models;
using Ix4Models.Interfaces;
using Ix4Models.SettingsDataModel;
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
        public CustomDataSourceTypes DataSourceType
        {
            get
            {
                return CustomDataSourceTypes.Csv;
            }
        }

        public UserControl GetControlForSettings(PluginsSettings settings)
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

        public void SaveSettings(PluginsSettings settings)
        {
            
        }
    }
}
