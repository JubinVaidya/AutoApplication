using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.ModelServices
{
    public interface ISale
    {
        int AutoId { get; set; }
        int CustomerID { get; set; }
        int SaleId { get; set; }
        int SalesAmount { get; set; }
        DateTime SalesDate { get; set; }
        string UserId { get; set; }
    }
}
