using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjMEF
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class MefInjection
    {
        private static CompositionContainer mycontainer;
        public static CompositionContainer MyContainer
        {
            get
            {
                if (mycontainer == null)
                {
                    var catalog = new DirectoryCatalog(".",
                       "MyProjectNamespace.*");

                    mycontainer = new CompositionContainer(catalog);

                }

                return mycontainer;
            }
        }
    }

    public interface ITab { }

    [Export(typeof(ITab))]
    public class HomeTab : ITab { }

    [Export(typeof(ITab))]
    public class GamesTab : ITab { }

    [Export(typeof(ITab))]
    public class WishlistTab : ITab { }

    [Export]
    public class Home
    {
        [ImportMany]
        private List<ITab> tabs;
    }

    [Export]
    public class Logger
    {
    }

    [Export]
    public class MyService
    {
        private Logger log;

        [ImportingConstructor]
        public MyService(Logger log)
        {
            this.log = log;
        }
    }


}
