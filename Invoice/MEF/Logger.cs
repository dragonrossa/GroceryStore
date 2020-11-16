using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace Invoice.MEF
{
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