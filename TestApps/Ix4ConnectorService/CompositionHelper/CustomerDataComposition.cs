using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace CompositionHelper
{
   public class CustomerDataComposition
    {
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
    }
}
