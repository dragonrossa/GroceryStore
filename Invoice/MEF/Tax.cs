using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Invoice.Repository;
using Invoice.MEF;

namespace Invoice.MEF
{


    [Export]
    public class Tax
    {
        //WithPDV p = new WithPDV(tax,user);
      //  WithPDV p = new WithPDV(GetDecimalTax(), ApplicationUserID());
                     
    }

    [Export]
    public class GetFullPriceWithTax
    {
        private Tax tax;

        [ImportingConstructor]
        public GetFullPriceWithTax(Tax tax)
        {
            this.tax = tax;
        }
        public GetFullPriceWithTax2(Tax tax)
        {
            //Get sum of all with tax
            //public decimal ViewBagsumOfAllWithTax(decimal tax, string user)
            //{
            //    //Get tax from Session
            //    // decimal realTax = Convert.ToDecimal(Session["realTax"]);

            //    //Sum of all items on bill with tax

            //    //Get sum of all with Tax
            //    decimal sumOfAllWithTax = (from t in db.Tax
            //                               join b in db.BillArticleModels
            //                               on t.ID equals b.TaxID
            //                               where b.UserID == user
            //                               select (((tax * b.PricePerUnitNoTax) + b.PricePerUnitNoTax) * b.Quantity)).Sum();

            //    return sumOfAllWithTax;
            //}
        }
    }
}