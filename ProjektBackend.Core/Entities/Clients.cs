using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackend.Core.Entities
{
    public class Clients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? ClientId { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter your postal code")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression("(?<!\\w)(\\(?(\\+|00)?48\\)?)?[ -]?\\d{3}[ -]?\\d{3}[ -]?\\d{3}(?!\\w)", ErrorMessage = "Please provide a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Please provide a valid email address")]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<Orders>? Orders { get; set; }
    }
}
