using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ix4Models
{
    public interface ICustomerDataConnector
    {
        string GetCustomerData();

        UserControl GetControlForSettings();
    }
}
