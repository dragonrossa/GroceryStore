using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.Helpers
{
    public class listOfAll
    {
        //Part from Bill
        public DateTime AccountDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string InvoiceCreator { get; set; }
        public string InvoiceRecipient { get; set; }

        //Part from Article
        public string Description { get; set; }

        //Part from Bill Article
        public int Quantity { get; set; }

        public decimal? PricePerUnitNoTax { get; set; }
        public decimal? FullPriceAllNoTax { get; set; }

        //Part from Tax

        public double Tax { get; set; }
     
    }
}