using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Invoice.Repository;

namespace Invoice.MEF
{

    [Export(typeof(ITax))]
    public class Tax: ITax
    {
        public decimal sumAllPDV(decimal pdv, string user)
        {
            return WithPDV.sumAllPDV(pdv, user);
        }
       
}    }


 