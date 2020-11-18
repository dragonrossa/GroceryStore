using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.MEF
{
    //Calling from Tax class - containst function for sum all with PDV
    public static class WithPDV
    {

        public static ApplicationDbContext db = new ApplicationDbContext();

        public static decimal sumAllPDV(decimal tax, string user)
        {
            return (from t in db.Tax
                 join b in db.BillArticleModels
                 on t.ID equals b.TaxID
                 where b.UserID == user
                 select (((tax * b.PricePerUnitNoTax) + b.PricePerUnitNoTax) * b.Quantity)).Sum();
        }

    }
    
}