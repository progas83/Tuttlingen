using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Ix4ConnectorService
{
    public class Ix4ServiceInstaller : Installer
    {
        private ServiceInstaller _serviceInstaller;
        private ServiceProcessInstaller _processInstaller;

        public Ix4ServiceInstaller()
        {
            _serviceInstaller = new ServiceInstaller();
            _serviceInstaller.ServiceName = DataManager.CurrentServiceInformation.ServiceName;
            _serviceInstaller.StartType = ServiceStartMode.Automatic;
            _serviceInstaller.AfterInstall += OnAfterServiceInstall;
            _serviceInstaller.BeforeInstall += OnBeforeServiceInstall;




            _processInstaller = new ServiceProcessInstaller();
            _processInstaller.Password = null;
            _processInstaller.Username = null;
            _processInstaller.Account = ServiceAccount.LocalSystem;

            Installers.Add(_serviceInstaller);
            Installers.Add(_processInstaller);
        }

        private void OnBeforeServiceInstall(object sender, InstallEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnAfterServiceInstall(object sender, InstallEventArgs e)
        {
            ServiceController sc = new ServiceController(DataManager.CurrentServiceInformation.ServiceName);
            sc.Start();
        }
    }
}
