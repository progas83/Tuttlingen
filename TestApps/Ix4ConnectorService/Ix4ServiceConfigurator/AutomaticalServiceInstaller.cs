using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ix4ServiceConfigurator
{
    internal class AutomaticalServiceInstaller
    {
       // private static readonly string _exePath = Assembly.GetExecutingAssembly().Location;

        private static readonly string servicePath = Ix4ConnectorService.Program.ServiceLocation;//  @"C:\Ilya\Tuttlingen\TestApps\Ix4ConnectorService\Ix4ConnectorService\bin\Debug\Ix4ConnectorService.exe";// Assembly.GetExecutingAssembly().Location;

       

        public static bool InstallService()
        {
            try
            {
              //  var res = Ix4ConnectorService.Program.ServiceLocation;

                // var utilPath = "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\InstallUtil.exe";

                //string installPath = string.Format("{0} {1}", utilPath, servicePath);// string.Format("C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\InstallUtil.exe {0}", servicePath);
                                                                                     //   var res = System.Diagnostics.Process.Start(utilPath, servicePath);// installPath);
                                                                                     //ManagedInstallerClass.InstallHelper(new string[] { _exePath });
                if(!ServiceInfoWrapper.Instance.ServiceExist)
                {
                    ManagedInstallerClass.InstallHelper(new string[] { servicePath });
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool UninstallService()
        {
            try
            {
                if(ServiceInfoWrapper.Instance.ServiceExist)
                {
                    ManagedInstallerClass.InstallHelper(new string[] { "/u", servicePath });
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
