using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Invoice.Helpers;

namespace Invoice.Models
{
    public class BillArticleModels:IBillArticleModels
    {
        [Key]
        public int ID { get; set; }

        //ID from BillModels
        public int BillID { get; set; }

        //ID from Tax
        public int TaxID { get; set; }

        //ID from Article
        public int ArticleID { get; set; }

        //Username from Identity
        [Column(TypeName = "varchar")]
        [MaxLength]
        public string UserID { get; set; }
        public int Quantity { get; set; }
        //After Bill Article - jedinična cijena stavke bez poreza
        //Price for one article without TAX
        [Column(TypeName = "money")]
        [Display(Name = "Price per unit")]
        //Full price for all articles on bill without TAX
        public decimal PricePerUnitNoTax { get; set; }
        //Full price for all articles without TAX = Quantity * PriceNoTax
        [Column(TypeName = "money")]
        public decimal FullPriceAllNoTax { get; set; }
     
    }
}