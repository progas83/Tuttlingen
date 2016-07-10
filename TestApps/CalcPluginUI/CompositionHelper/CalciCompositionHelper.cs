using CalcContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompositionHelper
{
    public class CalciCompositionHelper
    {
       // [Import(typeof(ICalculator))]
       [ImportMany]
        public ICalculator[] CalciPlugin { get; set; }

        public void AssembleCalculatorComponents()
        {
            try
            {
                var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

                var container = new CompositionContainer(catalog);

                container.ComposeParts(this);


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AssembleCalculatorComponentsE()
        {
            try
            {
                var aggregateCatalog = new AggregateCatalog();

                var directoryPath = string.Format("{0}\\{1}",string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)),"plugins");
                var directoryCatalog = new DirectoryCatalog(directoryPath, "*.dll");




                var asmCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

                aggregateCatalog.Catalogs.Add(directoryCatalog);
                aggregateCatalog.Catalogs.Add(asmCatalog);

                var container = new CompositionContainer(aggregateCatalog);

                container.ComposeParts(this);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetResult(int x1, int x2)
        {
            return CalciPlugin[0].GetNumber(x1, x2);
        }
    }
}
