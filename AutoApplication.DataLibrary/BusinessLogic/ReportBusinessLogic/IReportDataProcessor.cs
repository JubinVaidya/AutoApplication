using AutoApplication.DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.ReportBusinessLogic
{
   public interface IReportDataProcessor
    {
        IList<UserSaleCommissionReport> LoadUserCommissionReport();
    }
}
