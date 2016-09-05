﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ix4Models
{
    public static class ExtensionMethods
    {
        public static string SerializeObjectToString<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public static string Truncate(this string str, int maxLength)
        {
            if(string.IsNullOrEmpty(str))
            {
                return str;
            }
            return str.Length <= maxLength ? str : str.Substring(0, maxLength);
        }

    }
}
