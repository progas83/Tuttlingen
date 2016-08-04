﻿using Ix4Models.Interfaces;
using System;
using System.Xml.Serialization;

namespace Ix4Models.SettingsDataModel
{
    [Serializable]
    public class PluginsSettings
    {
        [XmlIgnore]
        public IPluginSettings[] AllAvailablePluginSettings { get; set; }
        public PluginsSettings()
        {
            MsSqlSettings = new MsSqlPluginSettings();
            XmlSettings = new XmlPluginSettings();
            CsvSettings = new CsvPluginSettings();
            AllAvailablePluginSettings = new IPluginSettings[] { MsSqlSettings, XmlSettings, CsvSettings };
        }
        public XmlPluginSettings XmlSettings { get; set; }

        public CsvPluginSettings CsvSettings { get; set; }

        public MsSqlPluginSettings MsSqlSettings { get; set; }

    }
}
