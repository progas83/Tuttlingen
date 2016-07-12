using Ix4Connector.Ix4WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Connector.Args
{
    public delegate void ExportDataAsyncCompletedEventHandler(object sender, ExportDataAsyncCompletedEventArgs e);

    public class ExportDataAsyncCompletedEventArgs : ExportDataCompletedEventArgs
    {
        public ExportDataAsyncCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState): 
            base(results, exception,cancelled, userState)
        {

        }
    }
}
