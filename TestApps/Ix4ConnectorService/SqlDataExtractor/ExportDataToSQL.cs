using Ix4Models.Interfaces;
using Ix4Models.SettingsDataModel;
using SimplestLogger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SqlDataExtractor
{
    public class ExportDataToSQL
    {
        private MsSqlPluginSettings _pluginSettings;
        private static Logger _loger = Logger.GetLogger();
        public ExportDataToSQL(IPluginSettings pluginSettings)
        {
            this._pluginSettings = pluginSettings as MsSqlPluginSettings;
        }

        internal void SaveDataToTable(string dataInstance, string exportData)
        {
            // Stream sr = new FileStream(, FileMode.Open);

          //  XmlNode node = new XmlNode();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(exportData);
            
           // MSG content = 
            XmlSerializer serializer = new XmlSerializer(typeof(MSG));
            using (FileStream fs = new FileStream(@"E:\Ilya\WV_Info\WW_LMS\WW_LMS\GSMSG.xml", FileMode.Open))
            {
                MSG res = (MSG)serializer.Deserialize(fs);
            }
                
            //TextReader reader = new StringReader(exportData);
            //var res = (NewDataSet)serializer.Deserialize(reader);
      //      NewDataSet wvExportData = new NewDataSet();
           
        }
    }
}
