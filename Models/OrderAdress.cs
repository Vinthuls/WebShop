using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class OrderAdress
    {
        [Key]
        public long OrderAdressId { get; set; }

        [Required(ErrorMessage = "First Name field is Required")][MaxLength(20)]
        [Column(TypeName = "varchar(20)")][Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name field is Required")][MaxLength(20)]
        [Column(TypeName = "varchar(20)")][Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Adress field is Required")]
        [EmailAddress][Display(Name = "Email Adress")]
        [Column(TypeName = "varchar(20)")][MaxLength(20)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adress field is Required")]
        [Column(TypeName = "varchar(50)")][MaxLength(20)]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Country field is Required")]
        [Column(TypeName = "varchar(20)")][MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Country { get; set; }

        [Required(ErrorMessage = "State field is Required")]
        [Column(TypeName = "varchar(20)")][MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string State { get; set; }

        [Required(ErrorMessage = "City field is Required")]
        [Column(TypeName = "varchar(20)")][MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip Code field is Required")][Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{2}(-\d{3})$", ErrorMessage = "Invalid Zip Code")]
        [Column(TypeName = "varchar(10)")]
        public string ZipCode { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
