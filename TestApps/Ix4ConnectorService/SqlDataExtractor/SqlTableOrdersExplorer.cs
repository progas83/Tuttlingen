using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ix4Models.Interfaces;

namespace SqlDataExtractor
{
    class SqlTableOrdersExplorer
    {
        private IPluginSettings pluginSettings;

        public SqlTableOrdersExplorer(IPluginSettings pluginSettings)
        {
            this.pluginSettings = pluginSettings;
        }

        internal LICSRequestOrder[] GetRequestOrders()
        {
            throw new NotImplementedException();
        }
    }
}
