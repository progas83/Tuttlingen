using SimplestLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Connector
{
    public class Ix4ConnectorManager
    {
        private static object _padlock = new object();
        private static Ix4ConnectorManager _manager;
        public static Ix4ConnectorManager Instance

        {
            get
            {
                if (_manager == null)
                {
                    lock (_padlock)
                    {
                        if (_manager == null)
                        {
                            _manager = new Ix4ConnectorManager();
                        }
                    }
                }
                return _manager;
            }
        }
        private Ix4ConnectorManager()
        {

        }
        private static Logger _loger = Logger.GetLogger();
        public IProxyIx4WebService GetRegisteredIx4WebServiceInterface(int clientId, string userName, string pwd)
        {
            Ix4WebService.LBSoapAuthenticationHeader header = new Ix4WebService.LBSoapAuthenticationHeader();
            header.ClientId = clientId;
            header.UserName = userName;
            header.Password = pwd;
            //_loger.Log("" + );
            //_loger.Log("" + );
            //_loger.Log("" + );
            ProxyIx4WebService client = new ProxyIx4WebService(header);
            
            return client;
        }
    }
}
