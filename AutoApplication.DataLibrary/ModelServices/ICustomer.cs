using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.ModelServices
{
    public interface ICustomer
    {
        string CustomerState { get; set; }
        string CustomerCity { get; set; }
        string CustomerFirstName { get; set; }
        int CustomerID { get; set; }
        string CustomerLastName { get; set; }
        string CustomerPhoneNumber { get; set; }
        string CustomerStreetAddress { get; set; }
        string CustomerSuiteNumber { get; set; }
        string CustomerZipCode { get; set; }
    }
}
