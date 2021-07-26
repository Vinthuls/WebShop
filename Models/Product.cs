using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }

        [Required][MaxLength(20, ErrorMessage = "Product name must not exeed 20 characters."),]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99, ErrorMessage = "Price must be in range of 0 to 999999.99")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 999999, ErrorMessage = "Quantity must be in range of 0 to 999999.99")]
        public decimal Quantity { get; set; }
        public IEnumerable<Theme> Themes { get; set; }
        //public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }

        [Required]
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
