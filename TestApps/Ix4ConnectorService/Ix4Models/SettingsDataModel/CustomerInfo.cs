using CryptoModule;
using Ix4Models.Interfaces;
using System;

namespace Ix4Models.SettingsDataModel
{
    [Serializable]
    public class CustomerInfo : ICryptor
    {
        public CustomerInfo()
        {
            ServiceName = CurrentServiceInformation.ServiceName;
            PluginSettings = new PluginsSettings()
            {
                CsvSettings = new CsvPluginSettings(),
                MsSqlSettings = new MsSqlPluginSettings(),
                XmlSettings = new XmlPluginSettings()
            };
        }



        public string ServiceName { get; set; }
        public string UserName { get; set; }

        public int ClientID { get; set; }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string ServiceEndpoint { get; set; }

        public bool Default { get; set; }

        public void Decrypt()
        {
            using (var cryptor = new Cryptor())
            {
                _password = cryptor.Decrypt(_password);
                if (PluginSettings.MsSqlSettings.DbSettings != null && !string.IsNullOrEmpty(PluginSettings.MsSqlSettings.DbSettings.DbUserName))
                {

                }
            }
        }

        public void Encrypt()
        {
            using (var cryptor = new Cryptor())
            {
                _password = cryptor.Encrypt(_password);
            }
            
        }

        #region PluginsSettings
        public PluginsSettings PluginSettings { get; set; }
        #endregion
    }
}
