using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.Helpers
{
    interface IBillArticleModels
    {
        int Quantity { get; set; }
        decimal PricePerUnitNoTax { get; set; }
        decimal FullPriceAllNoTax { get; set; }
    }
}