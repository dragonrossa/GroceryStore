using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoice.Helpers;
using Invoice.Models;
using Microsoft.AspNet.Identity;
using System.ComponentModel.Composition;
using Invoice.MEF;

namespace Invoice.Repository
{
    public class BillRepository:IRepository
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        MyService myService = Mef.Container.GetExportedValue<MyService>();

      //  public int GetTax { get; set; }


        //ViewData for Tax
       
        public object Tax()
        {
           return db.Tax.ToList().Select(u => new SelectListItem
            {
                Text = u.Percentage.ToString() + " % - " + u.Country.ToString(),
                Value = u.Percentage.ToString()
            }).ToList();
        }

        public object Articles()
        {
           return db.Article.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.ID.ToString()
            }).ToList();

           }

        public BillRepository()
        {
        }

        public BillRepository(ApplicationDbContext db)
        {
            this.db = db;
        }


       public void CreateNewBill(FormCollection form, int taxi, string ApplicationUser, string ApplicationUserID)
        {
            int article = Convert.ToInt32(form["articles"]);
            int tax = taxi;
            string quantity = form["quantity"];
            decimal realTax = Decimal.Divide(tax, 100);

            //Get tax ID
            int taxID = (from t in db.Tax where t.Percentage == tax select t.ID).FirstOrDefault();

            //Create new bill header
            var newBill = new BillModels
            {
                AccountDate = DateTime.Now,
                PaymentDate = DateTime.Now.AddDays(30),
                InvoiceCreator = ApplicationUser,
                InvoiceRecipient = ApplicationUser
            };

            db.Bills.Add(newBill);
            db.SaveChanges();


            //Create new BillArticle - articles on bill

            var articleDetails = db.Article.Where(u => u.ID == article).Select(u => u).FirstOrDefault();

            var newBillArticle = new BillArticleModels
            {
                BillID = newBill.ID,
                ArticleID = Convert.ToInt32(form["articles"]),
                UserID = ApplicationUserID,
                TaxID = taxID,
                Quantity = Convert.ToInt32(form["quantity"]),
                PricePerUnitNoTax = articleDetails.Price,
                FullPriceAllNoTax = articleDetails.Price * Convert.ToInt32(form["quantity"])
            };

            db.BillArticleModels.Add(newBillArticle);
            db.SaveChanges();
        }


        //Get details about Bill

        public IEnumerable<MyBill2> Bill()
        {


            //Create new object - list of All - stationed in Helpers - class list of All

            var result = from a in db.Article
                         join b in db.BillArticleModels on a.ID equals b.ArticleID
                         join c in db.Bills on b.BillID equals c.ID
                         join d in db.Tax on b.TaxID equals d.ID
                         select new MyBill2
                         {

                             AccountDate = c.AccountDate,
                             PaymentDate = c.PaymentDate,
                             InvoiceCreator = c.InvoiceCreator,
                             InvoiceRecipient = c.InvoiceRecipient,
                             Description = a.Description,
                             Quantity = b.Quantity,
                             PricePerUnitNoTax = b.PricePerUnitNoTax,
                             FullPriceAllNoTax = b.FullPriceAllNoTax,
                             Tax = d.Percentage

                         };


            return result;
        }


        //Get sum of all without tax
        public decimal ViewBagsumOfAllWithoutTax(string user)
        {
            //Get tax from Session
          //  decimal realTax = Convert.ToDecimal(Session["realTax"]);

            //Sum of all items on bill without tax

            decimal sumOfAllWithoutTax = (from s in db.BillArticleModels where s.UserID == user select s.FullPriceAllNoTax).Sum();

            return sumOfAllWithoutTax;
             }


        //Get sum of all with tax
        public decimal ViewBagsumOfAllWithTax(decimal tax, string user)
        {
            //Get tax from Session
           // decimal realTax = Convert.ToDecimal(Session["realTax"]);

            //Sum of all items on bill with tax

            //Get sum of all with Tax
            decimal sumOfAllWithTax = (from t in db.Tax
                                       join b in db.BillArticleModels
                                       on t.ID equals b.TaxID
                                       where b.UserID == user
                                       select (((tax * b.PricePerUnitNoTax) + b.PricePerUnitNoTax) * b.Quantity)).Sum();

            return sumOfAllWithTax;
        }



        //Get list of all 
        public IEnumerable<BillArticleModels> GetList(string id)
        {
            //username comes from Identity
           // var userFromBill = (from b in db.BillArticleModels select b.UserID).FirstOrDefault();
            
            //Get list if userID is id
            return db.BillArticleModels.Where(u => u.UserID == id).Select(u => u).ToList();

        }

        //Save changes to database
        public void Save()
        {
                db.SaveChanges();   
        }
    }
}