using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.ModelServices
{
    public interface ISale
    {
        int SaleID { get; set; }
        int PaymentID { get; set; }
        int AutoId { get; set; }
        int CustomerID { get; set; }
        string UserId { get; set; }
        double SalesAmount { get; set; }
        DateTime SalesDate { get; set; }
    }
}
