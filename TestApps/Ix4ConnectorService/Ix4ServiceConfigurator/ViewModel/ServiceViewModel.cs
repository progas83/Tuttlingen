using Ix4Models;
using Ix4Models.SettingsDataModel;
using Ix4Models.SettingsManager;
using Ix4ServiceConfigurator.Commands;
using Ix4ServiceConfigurator.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ix4ServiceConfigurator.ViewModel
{
    public class ServiceViewModel : BaseViewModel
    {
        public ServiceViewModel()
        {
            InstallationCommand InstallationCommand = new InstallationCommand();
            InstallationCommand.ServiceInfoNeedToUpdate += OnServiceInfoNeedToUpdate;
            InstallServiceCommand = InstallationCommand;
            UpdateCustomerInfo();
            MakeChangesCommad MakeChangesCommand = new MakeChangesCommad();
            MakeChangesCommand.CustomInformationSaved += OnCustomerInfoNeedToUpdate;
            MakeChangesCmd = MakeChangesCommand;
        }

        private void OnCustomerInfoNeedToUpdate(object sender, EventArgs e)
        {
            UpdateCustomerInfo();

        }

        private void UpdateCustomerInfo()
        {
            Customer = XmlConfigurationManager.Instance.GetCustomerInformation();
            
        }

        private void OnServiceInfoNeedToUpdate(object sender, EventArgs e)
        {
            OnPropertyChanged("ServiceExist");
        }
        CustomerInfo _customer;
        public CustomerInfo Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                OnPropertyChanged("Customer");
            }
        }

        public ICommand InstallServiceCommand { get; private set; }

        public ICommand MakeChangesCmd { get; set; }

        public string ServiceName
        {
            get
            {
                return CurrentServiceInformation.ServiceName;
            }
        }

        public bool ServiceExist
        {
            get { return ServiceInfoWrapper.Instance.ServiceExist; }
        }
    }
}
