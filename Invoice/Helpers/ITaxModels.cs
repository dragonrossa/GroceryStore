using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.Helpers
{
    interface ITaxModels
    {
        double Percentage { get; set; }
        string Country { get; set; }
    
    }
}