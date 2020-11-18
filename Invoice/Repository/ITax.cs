using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.Repository
{
    //Interface for MEF Testing
    public interface ITax
    {
        decimal sumAllPDV(decimal tax, string user);
       
    }
}