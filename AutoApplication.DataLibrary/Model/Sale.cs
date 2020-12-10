using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class Sale : ISale
    {
        public int SaleID { get; set; }
        public int AutoId { get; set; }
        public string UserId { get; set; }
        public int CustomerID { get; set; }
        public double SalesAmount { get; set; }
        public DateTime SalesDate { get; set; }

        public int PaymentID { get; set; }
        public string PaymentNameOnCard { get; set; }
        public string PaymentCardNumber { get; set; }
        public string PaymentCardExpiryDate { get; set; }
        public string PaymentSecurityCode { get; set; }


        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerStreetAddress { get; set; }
        public string CustomerSuiteNumber { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZipCode { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}
