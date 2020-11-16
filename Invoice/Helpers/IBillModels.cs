using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.Helpers
{
    interface IBillModels
    {
            DateTime PaymentDate { get; set; }
            string InvoiceCreator { get; set; }
            string InvoiceRecipient { get; set; }  
    }
}