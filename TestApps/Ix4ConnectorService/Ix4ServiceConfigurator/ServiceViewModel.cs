using Ix4ServiceConfigurator.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ix4ServiceConfigurator
{
    public class ServiceViewModel : INotifyPropertyChanged
    {
        public ServiceViewModel()
        {
            InstallationCommand InstallationCommand = new InstallationCommand();
            InstallationCommand.ServiceInfoNeedToUpdate += OnServiceInfoNeedToUpdate;
            InstallServiceCommand = InstallationCommand;
            
        }

        private void OnServiceInfoNeedToUpdate(object sender, EventArgs e)
        {
            OnPropertyChanged("ServiceExist");
        }

        public ICommand InstallServiceCommand { get; private set; }
  
        public string ServiceName
        {
            get
            {
                return DataManager.CurrentServiceInformation.ServiceName;
            }
        }

        public bool ServiceExist
        {
            get { return ServiceInfoWrapper.Instance.ServiceExist; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
