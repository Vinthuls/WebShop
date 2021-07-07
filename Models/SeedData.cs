﻿using System;
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
                    Name = "Splash Dudes", 
                    City = "San Jose" 
                }; 
                Supplier s2 = new Supplier { 
                    Name = "Soccer Town", 
                    City = "Chicago"
                };
                Supplier s3 = new Supplier {
                    Name = "Chess Co", 
                    City = "New York" 
                };
                Category c1 = new Category { Name = "Watersports" };
                Category c2 = new Category { Name = "Soccer" };
                Category c3 = new Category { Name = "Chess" };
                
                context.Products.AddRange(
                    new Product { 
                        Name = "Kayak", Price = 275,
                        Quantity = 10,
                        Description = "Ipsum Lorem",
                        IsOnSale = false,
                        Category = c1, Supplier = s1 
                    },
                    new Product {
                        Name = "Lifejacket", Price = 48.95m,
                        Quantity = 3,
                        Description ="Lorem impsum",
                        IsOnSale = false,
                        Category = c1, Supplier = s1 
                    }, new Product {
                        Name = "Soccer Ball", Price = 19.50m,
                        Quantity = 21,
                        Description = "Ipsum Lorem",
                        IsOnSale = false,
                        Category = c2, Supplier = s2 
                    },
                    new Product { 
                        Name = "Corner Flags", Price = 34.95m,
                        Quantity = 44,
                        Description = "Lorem impsum",
                        IsOnSale = false,
                        Category = c2, Supplier = s2 
                    }, 
                    new Product { 
                        Name = "Stadium", Price = 79500,
                        Quantity = 56,
                        Description = "Ipsum Lorem",
                        IsOnSale = false,
                        Category = c2, Supplier = s2 
                    },
                    new Product {
                        Name = "Thinking Cap", Price = 16,
                        Quantity = 231,
                        Description = "Lorem impsum",
                        IsOnSale = false,
                        Category = c3, Supplier = s3 
                    }, 
                    new Product { 
                        Name = "Unsteady Chair", Price = 29.95m,
                        Quantity = 643,
                        Description = "Lorem impsum",
                        IsOnSale = false,
                        Category = c3, Supplier = s3 
                    }, 
                    new Product { 
                        Name = "Human Chess Board", Price = 75,
                        Quantity = 345,
                        Description = "Ipsum Lorem",
                        IsOnSale = false,
                        Category = c3, Supplier = s3
                    }, 
                    new Product { 
                        Name = "Bling-Bling King", Price = 1200,
                        Quantity = 324,
                        Description = "Ipsum Lorem",
                        IsOnSale = false,
                        Category = c3, Supplier = s3 
                    });
                context.SaveChanges();
            }
        }
    }
}
