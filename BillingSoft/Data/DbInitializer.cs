using BillingSoft.Models;
using System;
using System.Linq;

namespace BillingSoft.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BillContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            //if (context.Product.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var category = new Category[]
            {
                new Category{ Name="Computadoras" },
                new Category{ Name="Celulares"}
            };
            foreach (Category c in category)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();


            var products = new Product[]
            {
                new Product{Code="MACBOOK-201x", Barcode="01203999911", Name="MacBook Pro Early 2014", CostPrice=1200.45M, Utility=300.00M, SalePrice=1500.45M, Stock=20, State=true, CategoryID=1},
                new Product{Code="ASUS-SERIES", Barcode="089334211", Name="Asus TX Alien Version", CostPrice=1000M, Utility=300.00M, SalePrice=1300.00M, Stock=17, State=true, CategoryID=1}
            };
            foreach (Product p in products)
            {
                context.Product.Add(p);
            }
            context.SaveChanges();
        }
    }
}
