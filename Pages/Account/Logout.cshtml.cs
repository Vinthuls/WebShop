using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager; 
        public LogoutModel(SignInManager<IdentityUser> signInMgr) 
        {
            signInManager = signInMgr; 
        }

        public async Task OnGetAsync() 
        { 
            await signInManager.SignOutAsync(); 
        }
    }
}
