namespace AutoApplication.DataLibrary.ModelServices
{
    public interface IPayment
    {
        string PaymentCardExpiryDate { get; set; }
        string PaymentCardNumber { get; set; }
        int PaymentID { get; set; }
        string PaymentNameOnCard { get; set; }
        string PaymentSecurityCode { get; set; }
    }
}