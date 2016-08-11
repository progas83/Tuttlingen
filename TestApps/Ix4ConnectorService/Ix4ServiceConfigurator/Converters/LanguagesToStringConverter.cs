using Ix4Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ix4ServiceConfigurator.Converters
{
    public class LanguagesToStringConverter : IValueConverter
    {

        private readonly string _engCulture = "en-US";
            private readonly string _deutschCulture = "de-DE";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Languages lang = Languages.English;
            if (value == null)
            {
                return value;
            }
                
            if (value!=null)
            {
                if(((string)value).Equals(_engCulture))
                {
                    lang = Languages.English;
                }
                if (((string)value).Equals(_deutschCulture))
                {
                    lang = Languages.Deutsch;
                }
            }
            return lang;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string cultureResult = _engCulture;
            if(value!=null)
            {
                Languages lang = (Languages)value;
                switch (lang)
                {
                    case Languages.Deutsch:
                        cultureResult = _deutschCulture;
                        break;
                    case Languages.English:
                        cultureResult = _engCulture;
                        break;
                    default:
                        cultureResult = _engCulture;
                        break;

                }
            }
            return cultureResult;
        }
    }
}
