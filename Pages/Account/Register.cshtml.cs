using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebShop.Models;
namespace WebShop.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public UserManager<MyUser> UserManager;
        public RegisterModel(UserManager<MyUser> userManager)
        {
            UserManager = userManager;
        }

        [BindProperty][Required][Display(Name = "User name")]
        public string UserName { get; set; }

        [BindProperty][Required][EmailAddress]
        public string Email { get; set; }

        [BindProperty][Required]
        public string  Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                MyUser user = new MyUser() { UserName = UserName, Email = Email };
                IdentityResult result = await UserManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    return RedirectToPage("Login");
                }
                else
                {
                    foreach(var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }         
            return Page();
        }
    }
}
