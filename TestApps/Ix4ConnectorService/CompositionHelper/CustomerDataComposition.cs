using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using Ix4Models;
using Ix4Models.SettingsDataModel;
using Ix4Models.Interfaces;

namespace CompositionHelper
{
    public class CustomerDataComposition
    {
        private PluginsSettings _pluginSettings;

        private CustomerDataComposition()
        {
            AssembleCustomerDataComponents();
        }

        public CustomerDataComposition(PluginsSettings pluginSettings) : this()
        {
            this._pluginSettings = pluginSettings;
        }

        [ImportMany]
        public System.Lazy<ICustomerDataConnector, IDictionary<string, object>>[] CustomerDataPlugins { get; set; }
        //       Logger _logger = Logger.GetLogger();
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
            catch (Exception ex)
            {
                //         _logger.Log(ex);
            }
        }

        public PluginsSettings SavePluginsSettings()
        {
            PluginsSettings ps = new PluginsSettings();
            try
            {
                foreach (var plugin in CustomerDataPlugins)
                {
                    plugin.Value.SaveSettings(_pluginSettings);
                }
            }
            catch (Exception ex)
            {
                //       _logger.Log(ex);
            }


            return _pluginSettings;
        }

        public UserControl GetDataSettingsControl(CustomDataSourceTypes dataSourceType)
        {
            UserControl uc = null;// resultData = string.Empty;

            try
            {
                foreach (var plugin in CustomerDataPlugins)
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
                //       _logger.Log(ex);
            }
            return uc;
        }

        public LICSRequestArticle[] GetRequestArticles()
        {
            LICSRequestArticle[] articles = new LICSRequestArticle[] { };
            try
            {
                IPluginSettings plugingSettings = _pluginSettings.AllAvailablePluginSettings.FirstOrDefault(pl => pl.CheckArticles);

                if (plugingSettings == null)
                {
                    //_logger.Log("There was not adjusted any article setting");
                    return articles;
                }
                foreach (var plugin in CustomerDataPlugins)
                {
                    if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(Enum.GetName(typeof(CustomDataSourceTypes),
                        plugingSettings.PluginType)))
                    {
                        articles = plugin.Value.GetRequestArticles(plugingSettings);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //         _logger.Log(ex);
            }
            return articles;

        }

        public LICSRequestDelivery[] GetRequestDeliveries()
        {
            LICSRequestDelivery[] deliveries = new LICSRequestDelivery[] { };
            IPluginSettings plugingSettings = _pluginSettings.AllAvailablePluginSettings.FirstOrDefault(pl => pl.CheckDeliveries);

            if (plugingSettings == null)
            {
                //_logger.Log("There was not adjusted any article setting");
                return deliveries;
            }

            try
            {
                foreach (var plugin in CustomerDataPlugins)
                {
                    if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(Enum.GetName(typeof(CustomDataSourceTypes), plugingSettings.PluginType)))
                    {
                        deliveries = plugin.Value.GetRequestDeliveries(plugingSettings);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //         _logger.Log(ex);
            }
            return deliveries;

        }

        public LICSRequestOrder[] GetRequestOrders()
        {
            LICSRequestOrder[] requestOrders = new LICSRequestOrder[] { };
            try
            {
                IPluginSettings plugingSettings = _pluginSettings.AllAvailablePluginSettings.FirstOrDefault(pl => pl.CheckOrders);
                if(plugingSettings==null)
                {
                    //_logger.Log("There was not adjusted any orders setting");
                    return requestOrders;
                }
                foreach (var plugin in CustomerDataPlugins)
                {
                    if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(Enum.GetName(typeof(CustomDataSourceTypes), plugingSettings.CheckOrders)))
                    {
                        requestOrders = plugin.Value.GetRequestOrders(plugingSettings);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //         _logger.Log(ex);
            }
            return requestOrders;
        }
    }
}
