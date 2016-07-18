using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rer = Enum.GetName(typeof(TestTy), TestTy.MsSql);
          //  string res =(string) TestTy.Xml;


            Console.WriteLine(rer);
            Console.ReadKey();
        }
    }
}
