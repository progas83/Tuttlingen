﻿using System;
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
        public ConnectorService()
        {
        //    AutoLog = true;
            CanPauseAndContinue = true;
            CanStop = true;
          //  CanShutdown = true;
            ServiceName = "NavisionService";// CurrentServiceInformation.ServiceName;
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
