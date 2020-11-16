using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TaxMEF.Models;

namespace TaxMEF
{

    class Program
    {
        private CompositionContainer _container;

        [Import(typeof(IRepository))]
        private IRepository helloWorld;

        private Program()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(@"../../lib"));

            _container = new CompositionContainer(catalog);

            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.helloWorld.HelloWorld());
            
            Console.ReadKey();
        }
    }
}
