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
    public class LoginModel : PageModel
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            SignInManager = signInManager;
        }

        [BindProperty][Required]
        public string UserName { get; set; }

        [BindProperty][Required]
        public string Password { get; set; }

        [BindProperty(SupportsGet = true)] 
        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) 
            {
                Microsoft.AspNetCore.Identity.SignInResult result 
                    = await SignInManager.PasswordSignInAsync(UserName, Password, false, false); 
                if (result.Succeeded) 
                {
                    return Redirect(ReturnUrl ?? "/"); 
                } 
                ModelState.AddModelError("", "Invalid username or password");
            }
            return Page();
        }
    }
}
