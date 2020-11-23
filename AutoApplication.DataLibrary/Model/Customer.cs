using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class Customer : ICustomer
    {
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "Customer's First Name")]
        public string CustomerFirstName { get; set; }
        [Required]
        [Display(Name = "Customer's Last Name")]
        public string CustomerLastName { get; set; }
        [Required]
        [Display(Name = "Customer's Street Address")]
        public string CustomerStreetAddress { get; set; }
        [Required]
        [Display(Name = "Customer'Suite/Apt Number")]
        public string CustomerSuiteNumber { get; set; }
        [Required]
        [Display(Name = "Customer's City Name")]
        public string CustomerCity { get; set; }
        [Required]
        [Display(Name = "Customer's State Name")]
        public string CustomerState { get; set; }
        [Required]
        [Display(Name = "Customer's Zip Code")]
        public string CustomerZipCode { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Customer's Phone Number")]
        public string CustomerPhoneNumber { get; set; }
    }
}
