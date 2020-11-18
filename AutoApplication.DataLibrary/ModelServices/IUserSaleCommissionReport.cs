using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.ModelServices
{
    public interface IUserSaleCommissionReport
    {

        string Id { get; set; }
        int AutoId { get; set; }
        double CommissionPercent { get; set; }
        double CommissionAmount { get; set; }
        double SalesAmount { get; set; }
        DateTime SalesDate { get; set; }
        string UserName { get; set; }
        string AutoMakerName { get; set; }
        string AutoModelName { get; set; }
        int AutoModelYear { get; set; }
    }
}
