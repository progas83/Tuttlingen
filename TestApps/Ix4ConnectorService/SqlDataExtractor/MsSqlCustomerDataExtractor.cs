using DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataExtractor
{
    [Export(typeof(ICustomerDataConnector))]
    [ExportMetadata(CurrentServiceInformation.NameForPluginMetadata, CurrentServiceInformation.ServiceName)]
    public class MsSqlCustomerDataExtractor : ICustomerDataConnector
    {
        public string GetCustomerData()
        {
            throw new NotImplementedException();
        }
    }
}
