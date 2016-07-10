using CalcContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subtraction
{
    [Export(typeof(ICalculator))]
    public class Class1 : ICalculator
    {

        public int GetNumber(int x1, int x2)
        {
            return (x1 - x2) * 2;
        }
    }
}
