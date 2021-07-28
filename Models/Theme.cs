using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Theme
    {
        [Key]
        public long ThemeId { get; set; }

        [Required][Display(Name = "Theme name")]
        [MaxLength(20, ErrorMessage = "Theme name must not exeed 20 characters."),]
        [Column(TypeName = "varchar(20)")]  
        public string Name { get; set; }

        [Required]
        public byte[] Image { get; set; }
        [NotMapped]
        public string GetImageBase64 => Convert.ToBase64String(Image);

        [Required]
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
