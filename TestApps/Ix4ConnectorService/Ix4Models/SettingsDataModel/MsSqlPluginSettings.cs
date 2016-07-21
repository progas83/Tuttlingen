using Ix4Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Models.SettingsDataModel
{
    [Serializable]
    public class MsSqlPluginSettings : IPluginSettings
    {
        public MsSqlPluginSettings()
        {
            DbSettings = new MsSqlSettings();
        }
        public MsSqlSettings DbSettings { get; set; }

        public bool IsActivated
        {
            get; set;
        }

        public bool CheckArticles
        {
            get; set;
        }

        public string ArticlesQuery
        {
            get; set;
        }

        public bool CheckDeliveries
        {
            get; set;
        }

        public string DeliveriesQuery
        {
            get; set;
        }

        public string PositionsQuery
        {
            get; set;
        }
    }
}
