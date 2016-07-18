﻿using Ix4ServiceConfigurator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ix4ServiceConfigurator.Commands
{
    public class MakeChangesCommad : ICommand
    {
        public event EventHandler CustomInformationSaved;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CustomerInfoViewModel customerChanges = new CustomerInfoViewModel();
            //  customerChanges.CustomInformationSaveComplete += OnCustomInfoSaveComplete;
            bool? customChangesResult = customerChanges.ShowCustomerInfoWindow();
            if (customChangesResult.HasValue && customChangesResult.Value)
            {
                if (CustomInformationSaved != null)
                {
                    CustomInformationSaved(null, null);
                }
            }

            customerChanges.Dispose();
            customerChanges = null;

        }
    }
}
