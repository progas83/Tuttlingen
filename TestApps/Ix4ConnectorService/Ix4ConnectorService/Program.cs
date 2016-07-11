using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Ix4ConnectorService
{
    public class Program
    {
        static void Main(string[] args)
        {

            ServiceBase.Run(new ConnectorService());
            //ServiceController sc = new ServiceController(DataManager.CurrentServiceInformation.ServiceName);
            //try
            //{
            //    if (sc.ServiceName == null)
            //    {
            //        SelfAutomaticalInstaller.InstallMe();
            //    }
            //    else
            //    {
            //        SelfAutomaticalInstaller.UninstallMe();
            //    }
            //}
            //catch(Exception ex)
            //{
            //    SelfAutomaticalInstaller.InstallMe();
            //}
           
        }

        public static string ServiceLocation
        {
            get
            {
                return Assembly.GetExecutingAssembly().Location;
            }
        }
    }
}
