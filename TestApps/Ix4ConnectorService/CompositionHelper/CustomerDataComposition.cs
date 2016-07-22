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

        //public CustomerDataComposition()
        //{

        //}

        public CustomerDataComposition(PluginsSettings pluginSettings)
        {
            this._pluginSettings = pluginSettings;
        }

        [ImportMany]
        public System.Lazy<ICustomerDataConnector,IDictionary<string,object>>[] CustomerDataPlagins { get; set; }

        public void AssembleCustomerDataComponents()
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

            }
        }

        public string GetCustomerData()
        {
            string resultData = string.Empty;
            foreach(var plugin in CustomerDataPlagins)
            {
                if(((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(CurrentServiceInformation.ServiceName))
                {
                    resultData = plugin.Value.GetCustomerData();
                    break;
                }
            }
            return resultData;
        }

        public PluginsSettings SavePluginsSettings()
        {
            PluginsSettings ps = new PluginsSettings();
            foreach (var plugin in CustomerDataPlagins)
            {
                plugin.Value.SaveSettings(ps);
            }
            return ps;
        }

        public UserControl GetDataSettingsControl(CustomDataSourceTypes dataSourceType)
        {
            UserControl uc = null;// resultData = string.Empty;
            foreach (var plugin in CustomerDataPlagins)
            {
                if (((string)plugin.Metadata[CurrentServiceInformation.NameForPluginMetadata]).Equals(Enum.GetName(typeof(CustomDataSourceTypes), dataSourceType)))
                {
                    uc = plugin.Value.GetControlForSettings(_pluginSettings);
                    break;
                }
            }
            return uc;
        }
        public LICSRequest GetCustomerDataFromXml(string fileName)
        {
            LICSRequest request = new LICSRequest();
            if (CustomerDataPlagins != null)
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
            return request;
        }

        public LICSRequestArticle[] GetRequestArticles(PluginsSettings msSqlPluginSettings)
        {
            LICSRequestArticle[] articles = new LICSRequestArticle[] { };
            if (CustomerDataPlagins != null)
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
            return articles;

        }

        public LICSRequestDelivery[] GetRequestDeliveries(PluginsSettings msSqlPluginSettings)
        {
            LICSRequestDelivery[] deliveries = new LICSRequestDelivery[] { };
            if (CustomerDataPlagins != null)
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
