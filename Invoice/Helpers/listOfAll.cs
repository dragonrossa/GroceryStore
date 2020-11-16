using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Invoice.Helpers
{

    //This class implements all interfaces for List View
    public class MyBill2 : IArticleModels, IBillArticleModels, IBillModels, ITaxModels
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

        public decimal PricePerUnitNoTax { get; set; }
        public decimal FullPriceAllNoTax { get; set; }

        //Part from Tax

        public double Tax { get; set; }

        //Other
        public decimal Price { get; set; }
        public double Percentage { get; set; }
        public string Country { get; set; }

    }


}