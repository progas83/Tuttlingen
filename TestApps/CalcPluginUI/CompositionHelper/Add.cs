using CalcContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionHelper
{
    [Export(typeof(ICalculator))]
    public class Add : ICalculator
    {
       
        public int GetNumber(int x1, int x2)
        {
            return x1 + x2;
        }
    }
}
