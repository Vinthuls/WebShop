using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public static class ProductViewModelFactory
    {
        public static ProductViewModel Read(Product p)
        {
            return new ProductViewModel {
                Product = p,
                ActionName = "Read",
                ThemeColor = "info",
                IsReadOnly = true,
                Categories = p is null ? Enumerable.Empty<Category>()
                                       : new List<Category> { p.Category },
                Suppliers = p is null ? Enumerable.Empty<Supplier>()
                                       : new List<Supplier> { p.Supplier },
            }; 
        }
        public static ProductViewModel Create(Product p, IEnumerable<Category> categories,
            IEnumerable<Supplier> suppliers)
        {
            return new ProductViewModel
            {
                Product = p,
                ActionName = "Create",
                ThemeColor = "primary",
                IsReadOnly = false,
                Categories = categories,
                Suppliers = suppliers,
            };

        }
        public static ProductViewModel Update(Product p, IEnumerable<Category> categories,
            IEnumerable<Supplier> suppliers)
        {
            return new ProductViewModel
            {
                Product = p,
                ActionName = "Update",
                ThemeColor = "secondary",
                IsReadOnly = false,
                Categories = p is null ? Enumerable.Empty<Category>()
                                       : categories,
                Suppliers = p is null ? Enumerable.Empty<Supplier>()
                                       : suppliers,
            };
        }
        public static ProductViewModel Delete(Product p, IEnumerable<Category> categories,
            IEnumerable<Supplier> suppliers)
        {
            return new ProductViewModel
            {
                Product = p,
                ActionName = "Delete",
                ThemeColor = "danger",
                IsReadOnly = true,
                Categories = p is null ? Enumerable.Empty<Category>()
                                       : categories,
                Suppliers = p is null ? Enumerable.Empty<Supplier>()
                                       : suppliers,
            };

        }
    }
}
