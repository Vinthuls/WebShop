using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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
            return View(new ProductPaging() {
                Products = ProductFilter(p => true,
                                currentPage, out int count),
                PaginationInfo = new PaginationInfo()
                {
                    TotalItems = count,
                    CurrentPage = currentPage,
                    ItemsPerPage = itemsPerPage
                }
            });
        }

        public IActionResult SelectCategory(long currentCategoryId, int currentPage = 1)
        {
            ViewBag.CurrentCategoryId = currentCategoryId;
            return View("Index", new ProductPaging()
            {
                Products = ProductFilter(p => p.CategoryId == currentCategoryId,
                                currentPage, out int count),
                PaginationInfo = new PaginationInfo()
                {
                    TotalItems = count,
                    CurrentPage = currentPage,
                    ItemsPerPage = itemsPerPage
                }
            });
        }

        public IActionResult SearchProduct(string name , int currentPage = 1)
        {
            ViewBag.Search = name;
            return View("Index", new ProductPaging()
            {
                Products = ProductFilter(p => p.Name.Contains(name), 
                                currentPage, out int count),
                PaginationInfo = new PaginationInfo()
                {
                    TotalItems = count,
                    CurrentPage = currentPage,
                    ItemsPerPage = itemsPerPage
                }
            });
        }

        private IEnumerable<Product> ProductFilter(
            Expression<Func<Product, bool>> predicate, int currentPage, out int count)
        {
            count = _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Where(predicate)
                    .Count();
            return _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Where(predicate)
                    .Skip((currentPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
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
