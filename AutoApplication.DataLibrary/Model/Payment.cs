using AutoApplication.DataLibrary.ModelServices;
using System.ComponentModel.DataAnnotations;

namespace AutoApplication.DataLibrary.Model
{
    public class Payment : IPayment
    {
        public int PaymentID { get; set; }

        [Required]
        [Display(Name = "Name On Payment Card")]
        public string PaymentNameOnCard { get; set; }

        [Required]
        [Display(Name = "Payment Card Number")]
        [DataType(DataType.CreditCard)]
        public string PaymentCardNumber { get; set; }

        [Required]
        [Display(Name = "Payment Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string PaymentCardExpiryDate { get; set; }


        [Required]
        [Display(Name = "Security Code")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Maximum 4 characters")]
        public string PaymentSecurityCode { get; set; }
    }
}
