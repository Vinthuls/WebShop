using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using Microsoft.AspNetCore.Identity;
using WebShop.Extensions;

namespace WebShop.Controllers
{
    public class CheckoutController : Controller
    {
        private DataContext dataContext;
        private UserManager<MyUser> userManager;
        private ShoppingCart cart;

        public CheckoutController(DataContext dataContext, UserManager<MyUser> userManager, ShoppingCart cart)
        {
            this.dataContext = dataContext;
            this.userManager = userManager;
            this.cart = cart;
        }

        public async Task<IActionResult> Index()
        {
            MyUser myUser = await userManager.GetUserAsync(HttpContext.User);
            return View("Checkout", new CheckoutViewModel()
            {
                ShoppingCart = cart,
                OrderAdress = new OrderAdress(),
                UserId = myUser?.Id ?? new Guid().ToString()
            });
        }

        [HttpPost]
        public async Task<IActionResult> CheckoutOrder([FromForm] CheckoutViewModel CheckoutViewModel)
        {
            CheckoutViewModel checkoutViewModel = CheckoutViewModel;
            checkoutViewModel.ShoppingCart = cart;
            if (ModelState.IsValid)
            {
                Order order = new()
                {
                    OrderId = default,
                    MyUserId = checkoutViewModel.UserId,
                    OrderAdress = checkoutViewModel.OrderAdress,
                    OrderDate = DateTime.Now,
                    TotalPrice = checkoutViewModel.ShoppingCart
                        .CartItems.Sum(ci => ci.Quantity * ci.Product.Price)

                };

                foreach (var cartItem in cart.CartItems)
                {
                    cartItem.Product.ProductId = default;
                    cartItem.Product.Supplier = default;
                    cartItem.Product.Category = default;
                    cartItem.Product.Themes = default;
                    dataContext.Add(new OrderItem
                    {
                        OrderId = default,
                        Order = order,
                        ProductId = default,
                        Product = cartItem.Product,
                        ProductPrice = cartItem.Product.Price,
                        Quantity = cartItem.Quantity,
                        ThemeId = cartItem.Theme.ThemeId
                    });
                }
                await dataContext.SaveChangesAsync();
                cart.ClearShoppingCart();
                return View("CheckoutConfirmation");
            }
            return View("Checkout", checkoutViewModel);
        }
    }
}
