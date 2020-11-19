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
        [DataType(DataType.DateTime)]
        public string PaymentCardExpiryDate { get; set; }


        [Required]
        [Display(Name = "Security Code")]
        public string PaymentSecurityCode { get; set; }
    }
}
