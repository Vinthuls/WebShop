using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    [Keyless]
    public class OrderItem
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long ThemeId { get; set; }
        public Theme Theme { get; set; }

        [Range(0, 999999999.99)]
        public decimal ProductPrice { get; set; }

        [Range(0, 999999)]
        public decimal Quantity { get; set; }
    }
}
