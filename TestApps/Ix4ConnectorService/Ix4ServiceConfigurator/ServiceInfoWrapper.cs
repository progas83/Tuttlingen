using Ix4Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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
                if(_serviceInfoWrapper==null)
                {
                    lock(_singletoneLocker)
                    {
                        if(_serviceInfoWrapper==null)
                        {
                            _serviceInfoWrapper = new ServiceInfoWrapper();
                        }
                    }
                }
                return _serviceInfoWrapper;
            }
        }

        private ServiceInfoWrapper()
        {
            CheckCurrentService();
        }
        private CustomServiceController _currentService = null;

        private CustomServiceController CurrentService
        {
            get
            {
                CheckCurrentService();
                return _currentService;
            }
        }

        private void CheckCurrentService()
        {
            lock (_padlock)
            {
                try
                {
                    CustomServiceController sc = new CustomServiceController(CurrentServiceInformation.ServiceName);
                    
                    if (!sc.Equals(_currentService))
                    {
                        _currentService = sc;
                    }


                    if (_currentService.ServiceName.Equals(CurrentServiceInformation.ServiceName))
                    {
                        _serviceExist = true;
                    }
                }
                catch (Exception ex)
                {
                    _serviceExist = false;
                }
            }
        }

        public ServiceControllerStatus ServiceStatus
        {
            get
            {
                 return CurrentService.Status;
            }
        }

        private bool _serviceExist = false;
        public bool ServiceExist
        {
            get
            {
                CheckCurrentService();
                return _serviceExist;
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
