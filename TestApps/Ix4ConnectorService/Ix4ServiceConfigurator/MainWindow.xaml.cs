using Ix4ServiceConfigurator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;


namespace Ix4ServiceConfigurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel _viewModel;
        public MainWindow()
        {
            var processExists = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;
            if(processExists)
            {
                MessageBox.Show(Locale.Properties.Resources.CurrentProcessExist);
            }
            InitResources();
            InitializeComponent();

            _viewModel = new MainWindowViewModel();

            UIMainCustomerInfo.PasswordSet(_viewModel.Customer.Password);
            this.DataContext = _viewModel;

            
        }

        private void InitResources()
        {
            ResourceDictionary resource = new ResourceDictionary();
            Uri url = new Uri("pack://application:,,,/Style/WindowsStyleDictionary.xaml", UriKind.Absolute);
            resource.Source = url;
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.Dispose();
            }
        }
    }
}
