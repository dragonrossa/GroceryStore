﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoice.Models;
using Microsoft.AspNet.Identity;
using Invoice.Repository;
using Invoice.Helpers;
using Invoice.MEF;
using static Invoice.MEF.Logger;

namespace Invoice.Controllers
{
    public class InvoiceController : Controller
    {
        //Potrebno je razviti sustav koji će omogućiti korisnicima stvaranje i pregledavanje faktura. 
        //Faktura se izdaje
        // nakon što se proda neki proizvod ili usluga.

        //Call Bill Repository
        BillRepository bill = new BillRepository();

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

        //ID of user - example 7de87fa3-2bd1-47f4-9fe4-ba33c59ac93b
        public string ApplicationUserID()
        {
            return User.Identity.GetUserId();
        }

        //GetTax 

        public int GetTax()
        {
            
            int tax = Convert.ToInt32(Session["tax"]);
            return tax;
        }

        public decimal GetDecimalTax()
        {
            decimal realTax = Decimal.Divide(GetTax(), 100);
            return realTax;
        }

       

        //First view - choose tax

        public ActionResult Index()
        {
            //List of tax
            ViewData["tax"] = bill.Tax();
            //Get username
            ViewBagApplicationUser();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            Session["tax"] = Convert.ToInt32(form["tax"]);
            Session["realTax"] = GetDecimalTax();
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
            ViewData["articles"] = bill.Articles();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {

            //Create new bill 

            bill.CreateNewBill(form, GetTax(), ApplicationUser(), ApplicationUserID());
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
            bill.Bill();
            //Sum of all articles without Tax
            ViewBag.sumOfAllWithoutTax = bill.ViewBagsumOfAllWithoutTax(ApplicationUserID());
            //Sum of all articles on bill with Tax
            ViewBag.sumOfAllWithTax = bill.ViewBagsumOfAllWithTax(GetDecimalTax(), ApplicationUserID());

            return View(bill.Bill());
        }

        public ActionResult NotFound()
        {
         


            return View();
        }
    }
}