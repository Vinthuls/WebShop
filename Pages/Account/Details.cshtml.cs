using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace WebShop.Pages.Account
{
    public class DetailsModel : PageModel
    {
        public UserManager<IdentityUser> UserManager { get; set; }
        public DetailsModel(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }
        public IdentityUser IdentityUser { get; set; }
        public async Task OnGet() 
        { 
            if(User.Identity.IsAuthenticated)
            {
                IdentityUser = await UserManager.FindByNameAsync(User.Identity.Name);
            }
        }
    }
}
