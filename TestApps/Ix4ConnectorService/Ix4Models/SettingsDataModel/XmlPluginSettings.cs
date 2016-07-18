using Ix4Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ix4Models.SettingsDataModel
{
    [Serializable]
    public class XmlPluginSettings
    {
   
   
        //[XmlIgnore]
        
        //{
        //    get { return CustomDataSourceTypes.Xml; }
        //}

        public bool IsActivated { get; set; }

        public string SourceFolder { get; set; }

        public string ProcessedFilesFolder { get; set; }

        public string Ix4RequestFilesFolder { get; set; }

    }
}
