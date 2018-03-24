using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3PalmsSecurity.ViewModels
{
    public class ContactUsViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }
    }
}