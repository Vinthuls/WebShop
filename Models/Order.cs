using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebShop.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public string MyUserId { get; set; }
        [NotMapped]
        public MyUser MyUser { get; set; }
        public DateTime OrderDate { get; set; }
        [Range(0, 999999999.99)]
        public decimal TotalPrice { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
