﻿using Ix4Models;
using Ix4Models.Interfaces;
using Ix4Models.SettingsDataModel;
using SqlDataExtractor.DatabaseSettings.View;
using SqlDataExtractor.DatabaseSettings.ViewModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace SqlDataExtractor
{
    [Export(typeof(ICustomerDataConnector))]
    [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.CustomDataSourceTypeMsSql)]

    public class MsSqlCustomerDataExtractor : ICustomerDataConnector
    {
        MainDBSettingsViewModel _msSqlPluginSettingsViewModel;
        MainDBSettindsView _msSqlPluginSettingsView;
        public UserControl GetControlForSettings(PluginsSettings settings)
        {
            //ManualMaping.View.ManualMappingView view = new ManualMaping.View.ManualMappingView();
            //view.DataContext = new ManualMaping.ViewModel.ManualMapperViewModel();
            if(_msSqlPluginSettingsView==null)
            {
                _msSqlPluginSettingsView = new MainDBSettindsView();
            }
            if(_msSqlPluginSettingsViewModel==null)
            {
                _msSqlPluginSettingsViewModel = new MainDBSettingsViewModel(settings.MsSqlSettings);
            }
           
            _msSqlPluginSettingsView.DataContext = _msSqlPluginSettingsViewModel;
            return _msSqlPluginSettingsView;
        }

        public void SaveSettings(PluginsSettings settings)
        {
            if(_msSqlPluginSettingsViewModel == null)
            {
                return;
            }
            if (_msSqlPluginSettingsViewModel.CurrentPluginSettings.IsActivated)
            {
                settings.MsSqlSettings = _msSqlPluginSettingsViewModel.CurrentPluginSettings;
            }
        }

        public LICSRequestArticle[] GetRequestArticles(IPluginSettings pluginSettings)
        {
            SqlTableArticleExplorer articleExplorer = new SqlTableArticleExplorer(pluginSettings);
            return articleExplorer.GetArticles();
        }

        public LICSRequestDelivery[] GetRequestDeliveries(IPluginSettings pluginSettings)
        {
            SqlTableDeliveryExplorer articleExplorer = new SqlTableDeliveryExplorer(pluginSettings);
            return articleExplorer.GetRequestDeliveries();
        }

        public LICSRequestOrder[] GetRequestOrders(IPluginSettings pluginSettings)
        {
            SqlTableOrdersExplorer ordersExplorer = new SqlTableOrdersExplorer(pluginSettings);
            return ordersExplorer.GetRequestOrders();
        }
    }
}
