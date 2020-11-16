using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice.Helpers
{
    interface IArticleModels
    {
        string Description { get; set; }
        //Price for one article
        decimal Price { get; set; }
    }
}