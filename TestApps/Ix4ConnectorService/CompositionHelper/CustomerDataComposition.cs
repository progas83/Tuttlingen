using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using Ix4Models;
using Ix4Models.SettingsDataModel;
using Ix4Models.Interfaces;
using SinplestLogger;

namespace CompositionHelper
{
   public class CustomerDataComposition
    {
        private static CustomerDataComposition _compositor;
        private static object _padlock = new object();
        public static CustomerDataComposition Instance
        {
            get
            {
                if (_compositor == null)
                {
                    lock(_padlock)
                    {
                        if(_compositor==null)
                        {
                            _compositor = new CustomerDataComposition();
                        }
                    }
                }


                return _compositor;
            }
          
        }
        private CustomerDataComposition()
        {
            AssembleCustomerDataComponents();
        }
        private PluginsSettings _pluginSettings;


        public CustomerDataComposition(PluginsSettings pluginSettings) : this()
        {
            this._pluginSettings = pluginSettings;
        }

        [ImportMany]
        public System.Lazy<ICustomerDataConnector,IDictionary<string,object>>[] CustomerDataPlagins { get; set; }
        Logger _logger = Logger.GetLogger();
        private void AssembleCustomerDataComponents()
        {
            try
            {
                var directoryPath = string.Format("{0}\\{1}", string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)), CurrentServiceInformation.PluginsSubdirectory);
                var directoryCatalog = new DirectoryCatalog(directoryPath, "*.dll");

                var aggregateCatalog = new AggregateCatalog();
                aggregateCatalog.Catalogs.Add(directoryCatalog);

                var container = new CompositionContainer(aggregateCatalog);

                container.ComposeParts(this);


            }
            catch(Exception ex)
            {
                _logger.Log(ex);
            }
        }

       private string GetCustomerData()
        {
            string resultData = string.Empty;
            try
            {
                foreach (var plugin in CustomerDataPlagins)
                {
                    if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(CurrentServiceInformation.ServiceName))
                    {
                        resultData = plugin.Value.GetCustomerData();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

           
            return resultData;
        }

        public PluginsSettings SavePluginsSettings()
        {
            PluginsSettings ps = new PluginsSettings();
            try
            {
                foreach (var plugin in CustomerDataPlagins)
                {
                    plugin.Value.SaveSettings(ps);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            
            return ps;
        }

        public UserControl GetDataSettingsControl(CustomDataSourceTypes dataSourceType)
        {
            UserControl uc = null;// resultData = string.Empty;
           
            try
            {
                foreach (var plugin in CustomerDataPlagins)
                {
                    if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(Enum.GetName(typeof(CustomDataSourceTypes), dataSourceType)))
                    {
                        uc = plugin.Value.GetControlForSettings(_pluginSettings);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }
            return uc;
        }
        public LICSRequest GetCustomerDataFromXml(string fileName)
        {
            LICSRequest request = new LICSRequest();
            try
            {
                foreach (var plugin in CustomerDataPlagins)
                {
                    if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(Enum.GetName(typeof(CustomDataSourceTypes), CustomDataSourceTypes.Xml)))
                    {
                        request = plugin.Value.GetCustomerDataFromXml(fileName);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }
            return request;
        }

        public LICSRequestArticle[] GetRequestArticles(PluginsSettings msSqlPluginSettings)
        {
            LICSRequestArticle[] articles = new LICSRequestArticle[] { };
            try
            {
                foreach (var plugin in CustomerDataPlagins)
                {
                    if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(Enum.GetName(typeof(CustomDataSourceTypes),
                        CustomDataSourceTypes.MsSql)))
                    {
                        articles = plugin.Value.GetRequestArticles(msSqlPluginSettings.MsSqlSettings);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }
            return articles;

        }

        public LICSRequestDelivery[] GetRequestDeliveries(PluginsSettings msSqlPluginSettings)
        {
            LICSRequestDelivery[] deliveries = new LICSRequestDelivery[] { };
            if (CustomerDataPlagins != null)
            {
                
            }

            try
            {
                foreach (var plugin in CustomerDataPlagins)
                {
                    if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(Enum.GetName(typeof(CustomDataSourceTypes), CustomDataSourceTypes.MsSql)))
                    {
                        deliveries = plugin.Value.GetRequestDeliveries(msSqlPluginSettings.MsSqlSettings);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }
            return deliveries;

        }
        //public ICustomerDataConnector GetDataConnector(CustomDataSourceTypes dataSourceType)
        //{
        //    //AssembleCustomerDataComponents();
        //    ICustomerDataConnector connector = null;

        //    return connector;

        //}
    }
}
