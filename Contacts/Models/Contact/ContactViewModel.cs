using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contacts.Models.Contact
{
    public class ContactViewModel
    {
        public decimal ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Field can't be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}