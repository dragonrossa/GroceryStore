using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoice.Helpers;
using Invoice.Models;
using Microsoft.AspNet.Identity;

namespace Invoice.Repository
{
    //base repository with basic database operations
    public interface IRepository
    {
        //object Tax
        object Tax();
        //object Articles
        object Articles();
        //Create new Bill
        void CreateNewBill(FormCollection form, int taxi, string ApplicationUser, string ApplicationUserID);
        //Create Bill for user
        IEnumerable<MyBill2> Bill();
        decimal ViewBagsumOfAllWithoutTax(string user);
        decimal ViewBagsumOfAllWithTax(decimal tax, string user);
        IEnumerable<BillArticleModels> GetList(string id);
        //Save changes to db
        void Save();
    }
}