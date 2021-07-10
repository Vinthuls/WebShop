using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Controllers
{
    public class FormController : Controller 
    {
        private DataContext _dataContext;
        private IEnumerable<Category> Categories => _dataContext.Categories;
        private IEnumerable<Supplier> Suppliers => _dataContext.Suppliers;

        public FormController(DataContext dataContext)
        {
            _dataContext = dataContext;
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

        public IActionResult Create()
        {
            ProductViewModel model = ProductViewModelFactory
                .Create(new Product(), Categories, Suppliers);
            return View("~/Views/Form/FormView.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {

            product.ProductId = default;
            product.Category = default;
            product.Supplier = default;
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");

        }

        public async Task<IActionResult> Update(long id)
        {
            Product product
                = await _dataContext.Products.FindAsync(id);
            ProductViewModel model
                = ProductViewModelFactory.Update(product, Categories, Suppliers);
            return View("~/Views/Form/FormView.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] Product product)
        {
            product.Category = default;
            product.Supplier = default;
            _dataContext.Products.Update(product);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Delete(long id)
        {
            Product product
                = await _dataContext.Products.FindAsync(id);
            ProductViewModel model
                = ProductViewModelFactory.Delete(product, Categories, Suppliers);
            return View("~/Views/Form/FormView.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] Product product)
        {
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
