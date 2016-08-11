using Ix4ServiceConfigurator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            InitResources();
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
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



        private void OnLanguageSelect(object sender, SelectionChangedEventArgs e)
        {
            InitializeComponent();
        }
    }
}
