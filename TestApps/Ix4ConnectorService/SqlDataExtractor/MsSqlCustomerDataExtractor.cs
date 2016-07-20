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

        public UserControl GetControlForSettings(PluginsSettings settings)
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

        public void SaveSettings(PluginsSettings settings)
        {
           
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
