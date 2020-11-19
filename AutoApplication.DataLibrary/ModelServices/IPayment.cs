using System.ComponentModel.DataAnnotations;

namespace AutoApplication.DataLibrary.ModelServices
{
    public interface IPayment
    {

        int PaymentID { get; set; }

        string PaymentCardExpiryDate { get; set; }

        string PaymentCardNumber { get; set; }

        string PaymentNameOnCard { get; set; }

        string PaymentSecurityCode { get; set; }
    }
}