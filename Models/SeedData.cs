using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShop.Images;
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
                    Name = "Nike", 
                    City = "New York" 
                };
                Category c1 = new Category { Name = "Shoes" };
                Category c2 = new Category { Name = "T-shirts" };
                Category c3 = new Category { Name = "Trousers" };

                Product p1 = new Product {
                    Name = "FORUM LOW UNISEX", Price = 1337,
                    Category = c1, Supplier = s1, Quantity = 69
                };
                
                Product p2 = new Product {
                    Name = "LOGO PANTS", Price = 420,
                    Category = c3, Supplier = s3, Quantity = 1337
                };

                Product p3 = new Product {
                    Name = "CLUB TEE - T-shirt", Price = 69,
                    Category = c2, Supplier = s2, Quantity = 420
                };
                context.Themes.AddRange(
                    new Theme {
                        Name = "core black",
                        Image = ImageConverter.ImageFromFilePathToByteArray(
                            @"Images\SeedImages\Abibas\core black.png"),
                        Product = p1,
                    },
                    new Theme {
                        Name = "footwear white",
                        Image = ImageConverter.ImageFromFilePathToByteArray(
                            @"Images\SeedImages\Abibas\footwear white.png"),
                        Product = p1,
                    },
                    new Theme {
                        Name = "arctic orange",
                        Image = ImageConverter.ImageFromFilePathToByteArray(
                            @"Images\SeedImages\Nike\arctic orange.png"),
                        Product = p2,
                    }, 
                    new Theme {
                        Name = "treeline",
                        Image = ImageConverter.ImageFromFilePathToByteArray(
                            @"Images\SeedImages\Nike\treeline.png"),
                        Product = p2,
                    },
                    new Theme {
                        Name = "black",
                        Image = ImageConverter.ImageFromFilePathToByteArray(
                            @"Images\SeedImages\Pumba\black.png"),
                        Product = p3,
                    },
                    new Theme {
                        Name = "medium gray heather",
                        Image = ImageConverter.ImageFromFilePathToByteArray(
                            @"Images\SeedImages\Pumba\medium gray heather.png"),
                        Product = p3,
                    });
                context.SaveChanges();
            }
        }
    }
}
