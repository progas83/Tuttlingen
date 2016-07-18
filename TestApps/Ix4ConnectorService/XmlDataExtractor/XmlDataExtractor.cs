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
using XmlDataExtractor.Settings.View;
using XmlDataExtractor.Settings.ViewModel;
using Ix4Models.Converters;
using Ix4Models.SettingsDataModel;
using Ix4Models.Interfaces;

namespace XmlDataExtractor
{
    [Export(typeof(ICustomerDataConnector))]
    [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.CustomDataSourceTypeXml)]
    //  [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.ServiceName)]
    //  [ExportMetadata(CurrentServiceInformation.NameForPluginDataSourceType, CustomDataSourceTypes.Xml)]
    public class XmlDataExtractor : ICustomerDataConnector
    {
        public CustomDataSourceTypes DataSourceType
        {
            get
            {
                return CustomDataSourceTypes.Xml;
            }
        }
        XamlFolderSettingsControl _xamlUserControl;
        XamlFolderSettingsViewModel _viewModel;
        XmlPluginSettings _xmlSettings;
        public UserControl GetControlForSettings(PluginsSettings settings)
        {
            _xmlSettings = settings.XmlSettings;
            if(_xamlUserControl == null)
            {
                _xamlUserControl = new XamlFolderSettingsControl();
            }
            if(_viewModel==null)
            {
                _viewModel = new XamlFolderSettingsViewModel(_xmlSettings);
            }
            _xamlUserControl.DataContext = _viewModel; ;
            return _xamlUserControl;// new UserControl() { Content = new Label() { Content = "I am no imülemented user control Of XML DaTA" } };
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
                licsRequest = customerInfo.ConvertToLICSRequest();
            }

            return licsRequest;
        }

       public void SaveSettings(PluginsSettings settings)
        {
            if(_xmlSettings.IsActivated)
            {
                settings.XmlSettings = _xmlSettings;
            }
        }
    }
}
