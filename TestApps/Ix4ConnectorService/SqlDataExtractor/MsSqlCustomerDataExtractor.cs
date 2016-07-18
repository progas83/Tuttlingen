using Ix4Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SqlDataExtractor
{
    [Export(typeof(ICustomerDataConnector))]
    [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.CustomDataSourceTypeMsSql)]
    // [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.ServiceName)]
    //  [ExportMetadata(CurrentServiceInformation.NameForPluginDataSourceType, CurrentServiceInformation.CustomDataSourceTypeMsSql)]
    public class MsSqlCustomerDataExtractor : ICustomerDataConnector
    {
        public UserControl GetControlForSettings()
        {
            ManualMaping.View.ManualMappingView view = new ManualMaping.View.ManualMappingView();
            view.DataContext = new ManualMaping.ViewModel.ManualMapperViewModel();
            return view;
        }

        public string GetCustomerData()
        {
            return "ddd";
        }

        public LICSRequest GetCustomerDataFromXml(string fileName)
        {
            return new LICSRequest();
        }
    }
}
