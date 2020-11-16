using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Invoice.Helpers;

namespace Invoice.Models
{
    public class BillModels:IBillModels
    {
        [Key]
        [Display(Name = "Number")]
        public int ID { get; set; }
        [Display(Name = "Account date")]
        public DateTime AccountDate { get; set; }
        [Display(Name = "Payment date")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Creator")]
        public string InvoiceCreator { get;set;}
        [Display(Name = "Recipient")]
        public string InvoiceRecipient { get; set; }



    }
}