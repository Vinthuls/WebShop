using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Models
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate(); 
            if (context.Products.Count() == 0 
                && context.Suppliers.Count() == 0 
                && context.Categories.Count() == 0)
            {
                Supplier s1 = new Supplier { 
                    Name = "Abibas", 
                    City = "Los Angeles" 
                }; 
                Supplier s2 = new Supplier { 
                    Name = "Pumba", 
                    City = "Chicago"
                };
                Supplier s3 = new Supplier {
                    Name = "Nike?", 
                    City = "New York" 
                };
                Category c1 = new Category { Name = "Shoes" };
                Category c2 = new Category { Name = "T-shirts" };
                Category c3 = new Category { Name = "Trousers" };

                Product p1 = new Product {
                    Name = "FORUM LOW UNISEX", Price = 275,
                    Category = c1, Supplier = s1, Quantity = 69
                };
                
                Product p2 = new Product {
                    Name = "LOGO PANTS", Price = 275,
                    Category = c3, Supplier = s3, Quantity = 1337
                };

                Product p3 = new Product {
                    Name = "CLUB TEE - T-shirt", Price = 70,
                    Category = c2, Supplier = s2, Quantity = 420
                };

                context.SaveChanges();
            }
        }
    }
}
