using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class Customer : ICustomer
    {
        public int CustomerID { get; set; }
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
