using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Connector
{
    public class Ix4ConnectorManager
    {
        private static object _padlock = new object();
        private static Ix4ConnectorManager _manager;
        public static Ix4ConnectorManager Instance

        {
            get
            {
                if (_manager == null)
                {
                    lock (_padlock)
                    {
                        if (_manager == null)
                        {
                            _manager = new Ix4ConnectorManager();
                        }
                    }
                }
                return _manager;
            }
        }
    }
}
