using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {      
        private DataContext _dataContext;
        private int itemsPerPage = 4;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index(int id = 1)
        {
            return View(new ProductPaging() {
                Products = _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Skip((id - 1) * itemsPerPage)
                    .Take(itemsPerPage),
                PaginationInfo = new PaginationInfo()
                {
                    TotalItems = _dataContext.Products.Count(),
                    CurrentPage = id,
                    ItemsPerPage = itemsPerPage
                }
            });
        }

        public IActionResult SelectCategory(long id)
        {
            IEnumerable<Product> products 
                =  _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Where(p => p.CategoryId == id);
            return View("Index", products);
        }

        public IActionResult SearchProduct(string name)
        {
            IEnumerable<Product> products
                = _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Where(p => p.Name.Contains(name));
            return View("Index", products);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
