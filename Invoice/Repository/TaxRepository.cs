using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.Repository
{
    public class TaxRepository:ITax
    {
        public  ApplicationDbContext db = new ApplicationDbContext();

        public decimal sumAllPDV(decimal tax, string user)
        {
            return (from t in db.Tax
                    join b in db.BillArticleModels
                    on t.ID equals b.TaxID
                    where b.UserID == user
                    select (((tax * b.PricePerUnitNoTax) + b.PricePerUnitNoTax) * b.Quantity)).Sum();
        }

    }
}