using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Pages.Roles
{
    public class ListModel : AdminPageModel
    {
        public UserManager<IdentityUser> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }
        public ListModel(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public void OnGet()
        {
            Roles = RoleManager.Roles;
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            IdentityRole role
                = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToPage();
        }

        public async Task<string> GetMembersString(string role)
        {
            IEnumerable<IdentityUser> users
                = await UserManager.GetUsersInRoleAsync(role);
            string result = users.Count() == 0
                ? "No members"
                : string.Join(", ", users.Take(3).Select(u => u.UserName).ToArray()); 
            return users.Count() > 3 ? $"{result}, (plus others)" : result;
        }
    }
}
