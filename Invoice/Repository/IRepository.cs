using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoice.Models;

namespace Invoice.Repository
{
    //base repository with basic database operations
    public interface IRepository
    {
        //Create Bill for user
        void CreateBill(FormCollection form);
        //Get list of orders
        IEnumerable<BillArticleModels> GetList(string id);
        //Save changes to db
        void Save();
    }
}