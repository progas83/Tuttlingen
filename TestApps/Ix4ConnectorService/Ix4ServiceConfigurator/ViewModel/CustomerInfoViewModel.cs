using Ix4ServiceConfigurator.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;
using CompositionHelper;
using Ix4Models;
using Ix4Models.SettingsDataModel;
using Ix4Models.SettingsManager;

namespace Ix4ServiceConfigurator.ViewModel
{

    public class CustomerInfoViewModel : BaseViewModel, ICommand, IDisposable
    {
        CustomerDataComposition _compositor;
        private CustomerInfoView _view;
        public CustomerInfoViewModel()
        {
            _view = new CustomerInfoView();
            _view.DataContext = this;
            _view.Closing += OnCustomerViewClosing;

            Customer = XmlConfigurationManager.Instance.GetCustomerInformation();

            _compositor = new CustomerDataComposition(Customer.PluginSettings);
            _compositor.AssembleCustomerDataComponents();
            //PluginControl = compositor.GetDataSettingsControl();



        }

        private CustomDataSourceTypes _selectedDataSource;
        public CustomDataSourceTypes SelectedDataSource
        {
            get { return _selectedDataSource; }
            set
            {
                _selectedDataSource = value;
                OnPropertyChanged("PluginControl");
            }
        }

        
        public UserControl PluginControl
        {
            get
            {
                return _compositor.GetDataSettingsControl(SelectedDataSource);
            }
        }
            //    ; set; }
        public bool? ShowCustomerInfoWindow()
        {
            if (_view != null)
            {
                _view.ShowDialog();
            }
            return _view.DialogResult;
        }
        private void OnCustomerViewClosing(object sender, CancelEventArgs e)
        {

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Customer.PluginSettings = _compositor.SavePluginsSettings();
            XmlConfigurationManager.Instance.UpdateCustomerInformation(Customer);
            _view.DialogResult = true;
            _view.Close();
            //if(CustomInformationSaveComplete!=null)
            //{
            //    CustomInformationSaveComplete(this, null);
            //}
        }

        //  public event EventHandler CustomInformationSaveComplete;

        public void Dispose()
        {
            _view = null;
            Customer = null;
        }

        private CustomerInfo _customer;

        public event EventHandler CanExecuteChanged;

        public CustomerInfo Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged("Customer");
            }
        }
    }
}
