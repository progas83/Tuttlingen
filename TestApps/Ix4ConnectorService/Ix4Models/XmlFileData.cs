using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Models
{
    public class XmlFileData
    {

        private static readonly string _xmlFileName =string.Format("{0}{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "\\configuration.xml");// @"C:\Ilya\ServiceProgram\configuration.xml";// "configuration.xml";
        public static string FileName { get { return _xmlFileName; } }
    }
}
