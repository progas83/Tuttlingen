using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DataManager;

namespace Ix4ConnectorService
{
   public class ConnectorService : ServiceBase
    {
        private string _username;
        private string _pwd;
        private string _clientId;
        public ConnectorService()
        {
            _username = "username";
            _pwd = "pwd";
            _clientId = "clientId";

            AutoLog = true;
            CanPauseAndContinue = true;
            CanStop = true;
          //  CanShutdown = true;
            ServiceName =  CurrentServiceInformation.ServiceName; //"NavisionService";//
            
        }

        //protected override void OnStart(string[] args)
        //{
        //    base.OnStart(args);
        //}

        //protected override void OnStop()
        //{
        //    base.OnStop();
        //}

        //protected override void OnContinue()
        //{
        //    base.OnContinue();
        //}

        //protected override void OnPause()
        //{
        //    base.OnPause();
        //}

        //protected override void OnShutdown()
        //{
        //    base.OnShutdown();
        //}
    }
}
