using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class XmlFileData
    {
        private static readonly string _xmlFileName = "configuration.xml";
        public static string FileName { get { return _xmlFileName; }}
    }
}
