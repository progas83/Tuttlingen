using Ix4Models;
using Ix4Models.Interfaces;
using Ix4Models.SettingsDataModel;
using SqlDataExtractor.DatabaseSettings.View;
using SqlDataExtractor.DatabaseSettings.ViewModel;
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
        public CustomDataSourceTypes DataSourceType
        {
            get
            {
                return CustomDataSourceTypes.MsSql ;
            }
        }
        MainDBSettingsViewModel _msSqlPluginSettingsViewModel;
        public UserControl GetControlForSettings(PluginsSettings settings)
        {
            //ManualMaping.View.ManualMappingView view = new ManualMaping.View.ManualMappingView();
            //view.DataContext = new ManualMaping.ViewModel.ManualMapperViewModel();
            MainDBSettindsView msSqlPluginSettingsView = new MainDBSettindsView();
            _msSqlPluginSettingsViewModel = new MainDBSettingsViewModel(settings.MsSqlSettings);
            msSqlPluginSettingsView.DataContext = _msSqlPluginSettingsViewModel;
            return msSqlPluginSettingsView;
        }

        public string GetCustomerData()
        {
            return "ddd";
        }

        public LICSRequest GetCustomerDataFromXml(string fileName)
        {
            return new LICSRequest();
        }

        public void SaveSettings(PluginsSettings settings)
        {
            if (_msSqlPluginSettingsViewModel.CurrentPluginSettings.IsActivated)
            {
                settings.MsSqlSettings = _msSqlPluginSettingsViewModel.CurrentPluginSettings;
            }
        }

        public LICSRequestArticle[] GetRequestArticles()
        {
            SqlTableArticleExplorer articleExplorer = new SqlTableArticleExplorer();
            return articleExplorer.GetArticles();
        }

        public LICSRequestDelivery[] GetRequestDeliveries()
        {
            SqlTableDeliveryExplorer articleExplorer = new SqlTableDeliveryExplorer();
            return articleExplorer.GetRequestDeliveries();
        }
    }
}
