using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    [Keyless]
    public class UserOrder
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public string MyUserId { get; set; }
        public MyUser Id { get; set; }
    }
}
