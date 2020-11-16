using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoice.Models;

namespace Invoice.Repository
{
    public class BillRepository:IRepository
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public BillRepository()
        {
        }

        public BillRepository(ApplicationDbContext db)
        {
            this.db = db;
        }


        public void CreateBill(FormCollection form)
        {
            string article = form["articles"];
            string tax = form["tax"];
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