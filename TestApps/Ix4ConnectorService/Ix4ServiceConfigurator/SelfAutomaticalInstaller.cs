using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ix4ServiceConfigurator
{
    class SelfAutomaticalInstaller
    {

        private static readonly string _exePath = Assembly.GetExecutingAssembly().Location;
        public static bool InstallMe()
        {
            try
            {
                                       
                   var servicePath = @"C:\Ilya\Tuttlingen\TestApps\Ix4ConnectorService\Ix4ConnectorService\bin\Debug\Ix4ConnectorService.exe";// Assembly.GetExecutingAssembly().Location;
                var utilPath = "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\InstallUtil.exe";

                string installPath = string.Format("{0} {1}", utilPath, servicePath);// string.Format("C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\InstallUtil.exe {0}", servicePath);
                var res = System.Diagnostics.Process.Start(utilPath, servicePath);// installPath);
                //ManagedInstallerClass.InstallHelper(new string[] { _exePath });
             //   ManagedInstallerClass.InstallHelper(new string[] { servicePath });
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool UninstallMe()
        {
            try
            {
                //ManagedInstallerClass.InstallHelper(
                //    new string[] { "/u", _exePath });
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
