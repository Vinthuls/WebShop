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
        private int itemsPerPage = 2;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index(int currentPage = 1)
        {
            IEnumerable<Product> products = _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Skip((currentPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            return View(new ProductPaging() {
                Products = products,
                PaginationInfo = new PaginationInfo()
                {
                    TotalItems = _dataContext.Products.Count(),
                    CurrentPage = currentPage,
                    ItemsPerPage = itemsPerPage
                }
            });
        }

        public IActionResult SelectCategory(long id, int currentPage = 1)
        {
            IEnumerable<Product> products 
                =  _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Where(p => p.CategoryId == id)
                    .Skip((currentPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            return View("Index", new ProductPaging()
            {
                Products = products,
                PaginationInfo = new PaginationInfo()
                {
                    TotalItems = _dataContext.Products
                                    .Include(p => p.Category)
                                    .Include(p => p.Supplier)
                                    .Where(p => p.CategoryId == id)
                                    .Count(),
                    CurrentPage = currentPage,
                    ItemsPerPage = itemsPerPage
                }
            });
        }

        public IActionResult SearchProduct(string name , int currentPage = 1)
        {
            IEnumerable<Product> products
                = _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Where(p => p.Name.Contains(name))
                    .Skip((currentPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            return View("Index", new ProductPaging()
            {
                Products = products,
                PaginationInfo = new PaginationInfo()
                {
                    TotalItems = _dataContext.Products
                                    .Include(p => p.Category)
                                    .Include(p => p.Supplier)
                                    .Where(p => p.Name.Contains(name))
                                    .Count(),
                    CurrentPage = currentPage,
                    ItemsPerPage = itemsPerPage
                }
            });
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
