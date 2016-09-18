﻿using CryptoModule;
using Ix4Models.Interfaces;
using System;
using System.Text;
using System.Xml.Serialization;

namespace Ix4Models.SettingsDataModel
{
    [Serializable]
    public class CustomerInfo : ICryptor
    {
        public CustomerInfo()
        {
            ServiceName = CurrentServiceInformation.ServiceName;
            PluginSettings = new PluginsSettings();
            ScheduleSettings = new SchedulerSettings();

            MailNotificationSettings = new MailNotificationSettings();
            //{
            //    CsvSettings = new CsvPluginSettings(),
            //    MsSqlSettings = new MsSqlPluginSettings(),
            //    XmlSettings = new XmlPluginSettings()
            //};
        }

        public string LanguageCulture { get; set; }

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
                PluginSettings.MsSqlSettings.DbSettings.Decrypt();
            }
        }

        public void Encrypt()
        {
            using (var cryptor = new Cryptor())
            {
                _password = cryptor.Encrypt(_password);
                PluginSettings.MsSqlSettings.DbSettings.Encrypt();
            }
            
        }

        #region PluginsSettings
        public PluginsSettings PluginSettings { get; set; }
        #endregion

 
        public SchedulerSettings ScheduleSettings { get; set; }

        public MailNotificationSettings MailNotificationSettings { get; set; }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(string.Format(" UserName = {0} ", UserName));
        //    sb.Append(string.Format(" ClientID = {0} ", ClientID));
        //    sb.Append(string.Format(" Password= {0} ", Password));
        //    sb.Append(string.Format(" ServiceEndpoint= {0} ", ServiceEndpoint));

        //    return sb.ToString();
        //}
    }
}
