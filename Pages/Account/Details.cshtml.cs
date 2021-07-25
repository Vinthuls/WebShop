using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using WebShop.Models;
namespace WebShop.Pages.Account
{
    public class DetailsModel : PageModel
    {
        public UserManager<MyUser> UserManager { get; set; }
        public DetailsModel(UserManager<MyUser> userManager)
        {
            UserManager = userManager;
        }
        public MyUser MyUser { get; set; }
        public async Task OnGet() 
        {           
            if(User.Identity.IsAuthenticated)
            {
                MyUser = await UserManager.FindByNameAsync(User.Identity.Name);
            }
        }
    }
}
