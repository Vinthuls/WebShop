using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class MyUser : IdentityUser
    {
        [NotMapped]
        public IEnumerable<Order> Orders { get; set; }
    }
}
