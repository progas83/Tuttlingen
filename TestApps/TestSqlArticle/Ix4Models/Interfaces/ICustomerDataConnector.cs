using Ix4Models.SettingsDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ix4Models.Interfaces
{
    public interface ICustomerDataConnector 
    {
        CustomDataSourceTypes DataSourceType { get; }

        void SaveSettings(PluginsSettings settings);

        string GetCustomerData();

        UserControl GetControlForSettings(PluginsSettings settings);

        LICSRequest GetCustomerDataFromXml(string fileName);
    }
}
