using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;

namespace Invoice.MEF
{
    public static class Mef
    {
        private static CompositionContainer container;

        public static CompositionContainer Container
        {
            get
            {
                if (container == null)
                {
                    var catalog =
                        new DirectoryCatalog(".", "MyProjectNamespace.*");

                    container = new CompositionContainer(catalog);
                }

                return container;
            }
        }

        

       
    }
}