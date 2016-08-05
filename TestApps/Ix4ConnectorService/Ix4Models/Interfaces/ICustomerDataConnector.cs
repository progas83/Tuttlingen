using Ix4Models.SettingsDataModel;
using System.Windows.Controls;

namespace Ix4Models.Interfaces
{
    public interface ICustomerDataConnector
    {
        void SaveSettings(PluginsSettings settings);

        UserControl GetControlForSettings(PluginsSettings settings);

        LICSRequestOrder[] GetRequestOrders(IPluginSettings pluginSettings);
        LICSRequestArticle[] GetRequestArticles(IPluginSettings pluginSettings);
        LICSRequestDelivery[] GetRequestDeliveries(IPluginSettings pluginSettings);

        LICSRequest[] GetRequestsWithArticles(IPluginSettings pluginSettings, Ix4RequestProps ix4Property);
    }
}
