using CompositionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CalcPluginUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var objCompHelper = new CalciCompositionHelper();

            objCompHelper.AssembleCalculatorComponents();

            var result = objCompHelper.GetResult(Convert.ToInt32(this.x1UI.Text), Convert.ToInt32(this.x2UI.Text));

            this.resultUI.Text = result.ToString();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var objCompHelper = new CalciCompositionHelper();

            objCompHelper.AssembleCalculatorComponentsE();

            var result = objCompHelper.GetResult(Convert.ToInt32(this.x1UI.Text), Convert.ToInt32(this.x2UI.Text));

            this.resultUI.Text = result.ToString();
        }
    }
}
