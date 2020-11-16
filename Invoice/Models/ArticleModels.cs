using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Invoice.Models
{
    public class ArticleModels
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z.0-9 ]{1,50}$", ErrorMessage = "Description must have min 1 and max 50 letters")]
        public string Description { get; set; }
        
        //Price for one article
        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        //For list of Articles
        public IEnumerable<ArticleModels> articles { get; set; }
    }
}