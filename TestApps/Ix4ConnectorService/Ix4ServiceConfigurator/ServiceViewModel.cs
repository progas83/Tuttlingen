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
     //   private ServiceInfoWrapper _serviceModel;
        public ServiceViewModel()
        {
       //     _serviceModel = new ServiceInfoWrapper();
            
        }

        public ICommand InstallService { get; private set; }
        public ICommand UninstallService { get; private set; }

       // private bool _serviceExist = false;
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
