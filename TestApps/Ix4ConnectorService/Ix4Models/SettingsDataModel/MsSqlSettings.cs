﻿using CryptoModule;
using Ix4Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Models.SettingsDataModel
{
    [Serializable]
    public class MsSqlSettings : ICryptor
    {

        private string _dbPassword;

        public string Password
        {
            get { return _dbPassword; }
            set { _dbPassword = value; }
        }

        private string _dbUserName;

        public string DbUserName
        {
            get { return _dbUserName; }
            set { _dbUserName = value; }
        }

        private string _dataBaseName;

        public string DataBaseName
        {
            get { return _dataBaseName; }
            set { _dataBaseName = value; }
        }

        private string _serverAdress;

        public string ServerAdress
        {
            get { return _serverAdress; }
            set { _serverAdress = value; }
        }

        public void Decrypt()
        {
            using (var cryptor = new Cryptor())
            {
                _dbPassword = cryptor.Decrypt(_dbPassword);
                _dbUserName = cryptor.Decrypt(_dbUserName);
                
            }
        }

        public void Encrypt()
        {
            using (var cryptor = new Cryptor())
            {
                _dbPassword = cryptor.Encrypt(_dbPassword);
                _dbUserName = cryptor.Encrypt(_dbUserName);
            }

        }
    }
}