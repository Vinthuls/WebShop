using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebShop.Models;
namespace WebShop.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<MyUser> signInManager; 
        public LogoutModel(SignInManager<MyUser> signInMgr) 
        {
            signInManager = signInMgr; 
        }

        public async Task OnGetAsync() 
        { 
            await signInManager.SignOutAsync(); 
        }
    }
}
