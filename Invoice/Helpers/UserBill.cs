using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invoice.Models;

namespace Invoice.Helpers
{
    public class UserBill
    {


        public BillModels billHelper { get; set; }
        public IEnumerable<BillArticleModels> billArticleHelper { get; set; }
        public IEnumerable<ArticleModels> articleHelper { get; set; }

        public List<object> objectList { get; set; }


    }
}