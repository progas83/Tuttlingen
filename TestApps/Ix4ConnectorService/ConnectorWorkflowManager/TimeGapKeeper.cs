using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorWorkflowManager
{
    public delegate void CheckAvailableData();

    public class TimeGapKeeper
    {
        private int _timeGap;

        public int TimeGap
        {
            get { return _timeGap; }
            private set { _timeGap = value; }
        }

        private TimeSign _timeGapSign;

        public TimeSign TimeGapSign
        {
            get { return _timeGapSign; }
            private set { _timeGapSign = value; }
        }
    }
}
