using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invoice.Models
{
    public class TaxModels
    {
        [Key]
        public int ID { get; set; }
        public double Percentage { get; set; }
        [RegularExpression(@"^[a-zA-Z.0-9 ]{1,30}$", ErrorMessage = "Country must have min 1 and max 30 letters")]
        public string Country { get; set; }

    }
}