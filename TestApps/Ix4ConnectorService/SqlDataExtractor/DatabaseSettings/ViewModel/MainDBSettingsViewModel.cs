using Ix4Models;
using Ix4Models.SettingsDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataExtractor.DatabaseSettings.ViewModel
{
   public class MainDBSettingsViewModel : BaseViewModel
    {
        MsSqlPluginSettings _msSqlPluginSettings;
        public MainDBSettingsViewModel(MsSqlPluginSettings msSqlPluginSettings)
        {
            CurrentPluginSettings = msSqlPluginSettings;
        }

        public MsSqlPluginSettings CurrentPluginSettings
        {
            get { return _msSqlPluginSettings; }
            private set { _msSqlPluginSettings = value; }
        }
        public bool IsActivated
        {
            get
            {
                return _msSqlPluginSettings.IsActivated;
            }
            set
            {
                _msSqlPluginSettings.IsActivated = value;
                OnPropertyChanged("IsActivated");
            }
        }

        public string ServerAdress
        {
            get { return _msSqlPluginSettings.DbSettings.ServerAdress; }
            set
            {
                _msSqlPluginSettings.DbSettings.ServerAdress = value;
                OnPropertyChanged("ServerAdress");
            }
        }

        public string DbName
        {
            get { return _msSqlPluginSettings.DbSettings.DataBaseName; }
            set { _msSqlPluginSettings.DbSettings.DataBaseName = value; OnPropertyChanged("DbName"); }
        }

        public string DbUserName
        {
            get { return _msSqlPluginSettings.DbSettings.DbUserName; }
            set { _msSqlPluginSettings.DbSettings.DbUserName = value; OnPropertyChanged("DbUserName"); }
        }

        public string DbPassword
        {
            get { return _msSqlPluginSettings.DbSettings.Password; }
            set { _msSqlPluginSettings.DbSettings.Password = value; OnPropertyChanged("DbPassword"); }
        }

        public bool CheckArticles
        {
            get { return _msSqlPluginSettings.CheckArticles; }
            set { _msSqlPluginSettings.CheckArticles = value; OnPropertyChanged("CheckArticles"); }
        }

        public string ArticlesQuery
        {
            get { return _msSqlPluginSettings.ArticlesQuery; }
            set { _msSqlPluginSettings.ArticlesQuery = value; OnPropertyChanged("ArticlesQuery"); }
        }

        public bool CheckDeliveries
        {
            get { return _msSqlPluginSettings.CheckDeliveries; }
            set { _msSqlPluginSettings.CheckDeliveries = value; OnPropertyChanged("CheckDeliveries"); }
        }

        public string DeliveriesQuery
        {
            get { return _msSqlPluginSettings.DeliveriesQuery; }
            set { _msSqlPluginSettings.DeliveriesQuery = value; OnPropertyChanged("DeliveriesQuery"); }
        }

        public string PositionsQuery
        {
            get { return _msSqlPluginSettings.PositionsQuery; }
            set { _msSqlPluginSettings.PositionsQuery = value; OnPropertyChanged("PositionsQuery"); }
        }


    }
}
