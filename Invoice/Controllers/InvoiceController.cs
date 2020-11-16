using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoice.Models;
using Microsoft.AspNet.Identity;
using Invoice.Repository;
using Invoice.Helpers;

namespace Invoice.Controllers
{
    public class InvoiceController : Controller
    {

        // Context
        private ApplicationDbContext db = new ApplicationDbContext();
        //Repository
        BillRepository bill = new BillRepository();
        //Object for new bill
        BillModels newBill = new BillModels();
        //Object for new bill article
        BillArticleModels newBillArticle = new BillArticleModels();
       


        //Potrebno je razviti sustav koji će omogućiti korisnicima stvaranje i pregledavanje faktura. 
        //Faktura se izdaje
        // nakon što se proda neki proizvod ili usluga.

        //Username of user - example rodjuga@gmail.com
        public string ApplicationUser()
        {
            string user = User.Identity.GetUserName();
            return user;
        }
        //ViewBag for user
        public string ViewBagApplicationUser()
        {
            ViewBag.user = User.Identity.GetUserName();
            return ViewBag.user;
        }


        public string UserID()
        {
            var user = User.Identity.GetUserId();
            return user;
        }

        //ID of user - example 7de87fa3-2bd1-47f4-9fe4-ba33c59ac93b
        public string ApplicationUserID()
        {
            return User.Identity.GetUserId();
        }

        //ViewData for Tax
        public object Tax()
        {
            ViewData["tax"] = db.Tax.ToList().Select(u => new SelectListItem
            {
                Text = u.Percentage.ToString() + " % - " + u.Country.ToString(),
                Value = u.Percentage.ToString()
            }).ToList();

            return ViewData["tax"];
        }

        //ViewData for Articles
        public object Articles()
        {
            ViewData["articles"] = db.Article.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.ID.ToString()
            }).ToList();

            return ViewData["articles"];
        }



        void CreateNewBill(FormCollection form)
        {
            int article = Convert.ToInt32(form["articles"]);
            int tax = Convert.ToInt32(Session["tax"]);
            string quantity = form["quantity"];
            decimal realTax = Decimal.Divide(tax, 100);

            //Get tax ID
            int taxID = (from t in db.Tax where t.Percentage == tax select t.ID).FirstOrDefault();

            //Create new bill header
            var newBill = new BillModels
            {
                AccountDate = DateTime.Now,
                PaymentDate = DateTime.Now.AddDays(30),
                InvoiceCreator = ApplicationUser(),
                InvoiceRecipient = ApplicationUser()
            };

            db.Bills.Add(newBill);
            db.SaveChanges();


            //Create new BillArticle - articles on bill

            var articleDetails = db.Article.Where(u => u.ID == article).Select(u => u).FirstOrDefault();

            var newBillArticle = new BillArticleModels
            {
                BillID = newBill.ID,
                ArticleID = Convert.ToInt32(form["articles"]),
                UserID = ApplicationUserID(),
                TaxID = taxID,
                Quantity = Convert.ToInt32(form["quantity"]),
                PricePerUnitNoTax = articleDetails.Price,
                FullPriceAllNoTax = articleDetails.Price * Convert.ToInt32(form["quantity"])
            };

            db.BillArticleModels.Add(newBillArticle);
            db.SaveChanges();
        }


        //Get Bill for some user

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
        public object ViewBagsumOfAllWithoutTax(string user2)
        {
            //Get tax from Session
            decimal realTax = Convert.ToDecimal(Session["realTax"]);

            //Sum of all items on bill without tax

            decimal sumOfAllWithoutTax = (from s in db.BillArticleModels where s.UserID == user2 select s.FullPriceAllNoTax).Sum();

            ViewBag.sumOfAllWithoutTax = sumOfAllWithoutTax;

            return ViewBag.sumOfAllWithoutTax;
        }


        //Get sum of all with tax
        public object ViewBagsumOfAllWithTax(string user2)
        {
            //Get tax from Session
            decimal realTax = Convert.ToDecimal(Session["realTax"]);

            //Sum of all items on bill with tax

            //Get sum of all with Tax
            decimal sumOfAllWithTax = (from t in db.Tax
                                       join b in db.BillArticleModels
                                       on t.ID equals b.TaxID
                                       where b.UserID == user2
                                       select (((realTax * b.PricePerUnitNoTax) + b.PricePerUnitNoTax) * b.Quantity)).Sum();




            ViewBag.sumOfAllWithTax = sumOfAllWithTax;
            return ViewBag.sumOfAllWithTax;
        }

   
        //First view - choose tax

        public ActionResult Index()
        {
            //List of tax
            Tax();
            //Get username
            ViewBagApplicationUser();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            int tax = Convert.ToInt32(form["tax"]);
            Session["tax"] = tax;
            decimal realTax = Decimal.Divide(tax, 100);
            Session["realTax"] = realTax;
            return RedirectToAction("Create");
        }

        //Create new bill article
        public ActionResult Create()
        {

            //Return info about user
            ViewBagApplicationUser();

            if(ApplicationUser() == "")
            {
                return RedirectToAction("NotFound", "Invoice");
            }

            //Get info for items in store
            Articles();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            
            //Create new bill 

            CreateNewBill(form);

            // bill.CreateBill(form);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            //Return info about user
            ViewBagApplicationUser();

            if (ApplicationUser() == "")
            {
                return RedirectToAction("NotFound", "Invoice");
            }

            //////////////////////////
            //Get Bill
            Bill();
            //Sum of all articles without Tax
            ViewBagsumOfAllWithoutTax(UserID()); 
            //Sum of all articles on bill with Tax
            ViewBagsumOfAllWithTax(UserID());


            return View(Bill());
        }

        public ActionResult NotFound()
        {

            return View();
        }
    }
}