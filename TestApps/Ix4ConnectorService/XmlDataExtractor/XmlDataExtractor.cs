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
    public class XmlDataExtractor : ICustomerDataConnector
    {
        XamlFolderSettingsControl _xamlUserControl;
        XamlFolderSettingsViewModel _viewModel;
       
        public UserControl GetControlForSettings(PluginsSettings settings)
        {
            XmlPluginSettings _xmlSettings = settings.XmlSettings;
            if(_xamlUserControl == null)
            {
                _xamlUserControl = new XamlFolderSettingsControl();
            }
            if(_viewModel==null)
            {
                _viewModel = new XamlFolderSettingsViewModel(_xmlSettings);
            }
            _xamlUserControl.DataContext = _viewModel; ;
            return _xamlUserControl;
        }

        //public LICSRequest GetCustomerDataFromXml(string fileName)
        //{

        //    XmlSerializer xS = new XmlSerializer(typeof(OutputPayLoad));
        //    LICSRequest licsRequest = new LICSRequest();
        //    using (FileStream fs = new FileStream(fileName, FileMode.Open))
        //    {
        //        OutputPayLoad customerInfo =(OutputPayLoad) xS.Deserialize(fs);
        //        licsRequest = customerInfo.ConvertToLICSRequest();
        //    }

        //    return licsRequest;
        //}

       public void SaveSettings(PluginsSettings settings)
        {
            if(_viewModel==null)
            {
                return;
            }
            if(_viewModel.CurrentPluginSettings.IsActivated)
            {
                settings.XmlSettings = _viewModel.CurrentPluginSettings;
            }
        }

        public LICSRequestArticle[] GetRequestArticles(IPluginSettings pluginSettings)
        {
            throw new NotImplementedException();
        }

        public LICSRequestDelivery[] GetRequestDeliveries(IPluginSettings pluginSettings)
        {
            throw new NotImplementedException();
        }

        public LICSRequestOrder[] GetRequestOrders(IPluginSettings pluginSettings)
        {
            throw new NotImplementedException();
        }
        private readonly int _deliveriesLimit = 20;
        public LICSRequest[] GetRequestsWithArticles(IPluginSettings pluginSettings, Ix4RequestProps ix4Property)
        {
            List<LICSRequest> requests = new List<LICSRequest>();
            if(pluginSettings.CheckArticles)
            {
                LICSRequest request = new LICSRequest();
                switch (ix4Property)
                {
                    
                    case Ix4RequestProps.Articles:
                        request.ArticleImport = GetRequestArticles(pluginSettings);
                        requests.Add(request);
                        break;
                    case Ix4RequestProps.Orders:
                        request.ArticleImport = GetRequestArticles(pluginSettings);
                        request.OrderImport = GetRequestOrders(pluginSettings);
                        requests.Add(request);
                        break;
                    case Ix4RequestProps.Deliveries:
                      //  LICSRequestDelivery[] deliveries = GetRequestDeliveries(pluginSettings);
                      //  List<LICSRequestDelivery> deliveryList = new List<LICSRequestDelivery>();
                      //  if(deliveries.Length>_deliveriesLimit)
                      //  {
                      //      int i = 0;
                      //      foreach(var deliv in deliveries)
                      //      {
                      //          if(i<=_deliveriesLimit)
                      //          {
                      //              deliveryList.Add(deliv);
                      //              i++;
                      //          }
                      //          else
                      //          {
                      //              i = 0;
                      //              request.DeliveryImport = deliveryList.ToArray();
                      //              requests.Add(request);
                      //              deliveryList = new List<LICSRequestDelivery>();
                      //          }
                      //      }
                      //  }
                      //  request.ArticleImport = GetRequestArticles(pluginSettings);
                      ////  request.OrderImport = GetRequestOrders(pluginSettings);
                      //  requests.Add(request);
                        break;
                    default:
                        break;
                }
            }
            
            return requests.ToArray();
        }
    }
}
