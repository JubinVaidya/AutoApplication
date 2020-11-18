using AutoApplication.DataLibrary.ModelServices;

namespace AutoApplication.DataLibrary.Model
{
    public class Payment : IPayment
    {
        public int PaymentID { get; set; }
        public string PaymentNameOnCard { get; set; }
        public string PaymentCardNumber { get; set; }
        public string PaymentCardExpiryDate { get; set; }
        public string PaymentSecurityCode { get; set; }
    }
}
