using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IX4InterfaceExample
{
    /// <summary>
    /// HelperClass for real UTF8 encoding
    /// </summary>
    internal class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }

}
