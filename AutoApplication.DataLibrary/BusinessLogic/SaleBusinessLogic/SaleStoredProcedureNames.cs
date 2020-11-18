using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.SaleBusinessLogic
{
    public static class SaleStoredProcedureNames
    {
        public static string StoreCustomerInformation { get { return "dbo.spStoreCustomerInformation @CustomerID, @CustomerFirstName, @CustomerLastName, @CustomerStreetAddress, @CustomerSuiteNumber, @CustomerCity,@CustomerState, @CustomerZipCode,@CustomerPhoneNumber"; } }
        public static string StoreSaleInformation { get { return "dbo.spStoreSalesInformation @SaleID, @AutoID , @CustomerID , @UserID ,  @PaymentID ,  @SalesDate ,@SalesAmount"; } }
        public static string StorePaymentInformation { get { return "dbo.spStorePaymentInformation @PaymentID, @PaymentNameOnCard, @PaymentCardNumber, @PaymentCardExpiryDate, @PaymentSecurityCode"; } }
        public static string GetHighestCustomerID { get { return "dbo.spGetHighestCustomerId"; } }
        public static string GetHighestPaymentID { get { return "dbo.spGetHighestPaymentId"; } }
        public static string GetHighestSaleID { get { return "dbo.spGetHighestSaleId"; } }
    }
}
