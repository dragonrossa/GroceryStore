using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.MEF
{
    public class WithPDV
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        //Get sum of all with tax
        //Get tax from Session
        // decimal realTax = Convert.ToDecimal(Session["realTax"]);

        //Sum of all items on bill with tax

        //Get sum of all with Tax

        public WithPDV(decimal tax, string user)
        {
            decimal sumOfAllWithTax = (from t in db.Tax
                                       join b in db.BillArticleModels
                                       on t.ID equals b.TaxID
                                       where b.UserID == user
                                       select (((tax * b.PricePerUnitNoTax) + b.PricePerUnitNoTax) * b.Quantity)).Sum();

        }

    }
    
}