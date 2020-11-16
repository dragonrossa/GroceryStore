namespace Invoice.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Invoice.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Invoice.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Invoice.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var articles = new List<ArticleModels> {

            //new ArticleModels  {
            //    Description = "Apple",
            //    Price = 5
            //     } ,
            //new ArticleModels
            //{
            //    Description="Banana",
            //    Price = 10
            //},
            //new ArticleModels
            //{
            //    Description="Pear",
            //    Price = 15
            //},
            // new ArticleModels
            //{
            //    Description="Orange",
            //    Price = 12
            //},
            //   new ArticleModels
            //{
            //    Description="Kiwi",
            //    Price = 15
            //},
            //     new ArticleModels
            //{
            //    Description="Lemon",
            //    Price = 16
            //}
            //};

            //var tax = new List<TaxModels> {

            //new TaxModels  {
            //    Percentage = 25,
            //    Country = "Croatia"
            //     } ,
            //new TaxModels
            //{
            //    Percentage=17,
            //    Country = "BiH"
            //},
            //new TaxModels
            //{
            //    Percentage=13,
            //    Country = "Slovenia"
            //}
            //};

            //context.Article.AddRange(articles);
            //context.Tax.AddRange(tax);

            //context.SaveChanges();
        }
    }
}
