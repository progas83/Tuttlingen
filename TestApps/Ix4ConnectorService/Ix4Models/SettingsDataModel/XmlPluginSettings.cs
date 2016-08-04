using Ix4Models.Interfaces;
using System;
using System.Xml.Serialization;

namespace Ix4Models.SettingsDataModel
{
    [Serializable]
    public class XmlPluginSettings : IPluginSettings
    {
        public bool IsActivated { get; set; }

        public string SourceFolder { get; set; }

        public string ProcessedFilesFolder { get; set; }

        public string Ix4RequestFilesFolder { get; set; }

        [XmlIgnore]
        public CustomDataSourceTypes PluginType
        {
            get
            {
                return CustomDataSourceTypes.Xml;
            }
        }

        public bool CheckArticles
        {
            get; set;
        }

        public bool CheckOrders
        {
            get; set;
        }

        public bool CheckDeliveries
        {
            get; set;
        }
    }
}
