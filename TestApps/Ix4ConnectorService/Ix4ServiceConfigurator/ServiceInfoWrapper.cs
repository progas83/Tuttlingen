using Ix4Models;
using Ix4ServiceConfigurator.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ix4ServiceConfigurator
{
    class ServiceInfoWrapper
    {

        private static object _padlock = new object();

        private static object _singletoneLocker = new object();
        private static ServiceInfoWrapper _serviceInfoWrapper = null;

        public static ServiceInfoWrapper Instance
        {
            get
            {
                if (_serviceInfoWrapper == null)
                {
                    lock (_singletoneLocker)
                    {
                        if (_serviceInfoWrapper == null)
                        {
                            _serviceInfoWrapper = new ServiceInfoWrapper();
                        }
                    }
                }
                return _serviceInfoWrapper;
            }
        }
       // System.Timers.Timer _checkServiceStatusTimer;
        private ServiceInfoWrapper()
        {
          //  CheckCurrentService();
            //_checkServiceStatusTimer = new System.Timers.Timer(10000);
            //_checkServiceStatusTimer.AutoReset = true;
            //_checkServiceStatusTimer.Elapsed += OnCheckServiceStatus;
            //_checkServiceStatusTimer.Enabled = true;

        }
  //      public event EventHandler<ServiceControllerStatusEventArg> ServiceStatusChanged;
        //private void OnCheckServiceStatus(object sender, ElapsedEventArgs e)
        //{
        //    if (ServiceExist)
        //    {
        //        ServiceControllerStatus currentServiceStatus = CurrentService.Status;
        //        if (ServiceStatus != currentServiceStatus && ServiceStatusChanged != null)
        //        {
        //            ServiceStatusChanged(this, new ServiceControllerStatusEventArg(currentServiceStatus));
        //        }

        //    }
        //}

        private ServiceController _currentService = null;

        private ServiceController CurrentService
        {
            get
            {
              //  CheckCurrentService();
                return ServiceController.GetServices().FirstOrDefault(item => item.ServiceName.Equals(CurrentServiceInformation.ServiceName)); //_currentService;
            }
        }

        //private void CheckCurrentService()
        //{
        //    lock (_padlock)
        //    {
        //        try
        //        {
        //            ServiceController sc = 

        //            if (!sc.Equals(_currentService))
        //            {
                        
        //                _currentService = sc;
        //            }


        //            if (_currentService.ServiceName.Equals(CurrentServiceInformation.ServiceName))
        //            {
        //                _serviceExist = true;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            _serviceExist = false;
        //        }
        //    }
      //  }

      //  private ServiceControllerStatus _currentServiceStatus;
        public ServiceControllerStatus ServiceStatus
        {
            get
            {
                return CurrentService!=null ? CurrentService.Status : ServiceControllerStatus.Stopped;
            }
        }

     
        public bool ServiceExist
        {
            get
            {
                return CurrentService != null;
            }
        }

        public void StopService()
        {
            try
            {
                if (CurrentService != null)
                {
                    CurrentService.Stop();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void StartService()
        {
            try
            {
                if (CurrentService != null)
                {
                    CurrentService.Start();
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
