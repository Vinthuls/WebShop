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

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products
                = _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier);
            return View(products);
        }
        public async Task<IActionResult> SelectCategory(long id)
        {
            IEnumerable<Product> products 
                = await _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .FirstOrDefaultAsync(p => p.ProductId == id) as IEnumerable<Product>;
            return View("Index", products);

        }

        public async Task<IActionResult> Read(long id)
        {
            Product product 
                = await _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .FirstOrDefaultAsync(p => p.ProductId == id);
            ProductViewModel model = ProductViewModelFactory.Read(product);
            return View("~/Views/Form/FormView.cshtml", model);
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
