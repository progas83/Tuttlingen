﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Models.SettingsDataModel
{
    [Serializable]
    public class PluginsSettings
    {
        public XmlPluginSettings XmlSettings { get; set; }

        public CsvPluginSettings CsvSettings { get; set; }

        public MsSqlPluginSettings MsSqlSettings { get; set; }
    }
}
