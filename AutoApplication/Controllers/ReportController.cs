using AutoApplication.DataLibrary.BusinessLogic.ReportBusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic.UserBusinessLogic;
using AutoApplication.DataLibrary.Model;
using AutoApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoApplication.Controllers
{
    public class ReportController : Controller
    {
        IReportDataProcessor _reportDataProcessor;
        IUserDataProcessor _userDataProcessor;
        UserSaleReportViewModel _userSaleReportViewModel;

        public ReportController(IReportDataProcessor reportDataProcessor, IUserDataProcessor userDataProcessor, UserSaleReportViewModel userSaleReportViewModel)
        {
            _reportDataProcessor = reportDataProcessor;
            _userDataProcessor = userDataProcessor;
            _userSaleReportViewModel = userSaleReportViewModel;
        }


        // GET: Report
        public ActionResult Index()
        {
            IList<UserSaleCommissionReport> listOfSalesReports = _reportDataProcessor.LoadUserCommissionReport();
            IList<SalesPerson> listOfSalesPeople = _userDataProcessor.FindAllSalesPeople();
            foreach(SalesPerson sp  in listOfSalesPeople)
            {
                double TotalSalesMade = listOfSalesReports.Where(y => y.Id == sp.Id).Sum(x => x.SalesAmount);
                double commissionPercent = listOfSalesReports.Where(y => y.Id == sp.Id).Select(y => y.CommissionPercent).FirstOrDefault();
                sp.TotalCommission = commissionPercent / 100 * TotalSalesMade;
            }

            //var ListOfUserNames = listOfSalesReports.Select(x => x.UserName).Distinct().ToList();

            return View(listOfSalesPeople);
        }
        [HttpGet]
        public ActionResult Detail(string id)
        {
            IList<UserSaleCommissionReport> listOfSalesReports = _reportDataProcessor.LoadUserCommissionReport();
            IList<SalesPerson> listOfSalesPeople = _userDataProcessor.FindAllSalesPeople();
            _userSaleReportViewModel.SalePerson = listOfSalesPeople.Where(x => x.Id == id).FirstOrDefault();
            foreach(UserSaleCommissionReport uscr in listOfSalesReports)
            {
                uscr.CommissionAmount = uscr.SalesAmount * uscr.CommissionPercent/100;
            }
            double TotalSalesMade = listOfSalesReports.Where(y => y.Id == id).Sum(x => x.SalesAmount);
            double commissionPercent = listOfSalesReports.Where(y => y.Id == id).Select(y => y.CommissionPercent).FirstOrDefault();
            _userSaleReportViewModel.SalePerson.TotalCommission = commissionPercent / 100 * TotalSalesMade;

            _userSaleReportViewModel.UserSaleCommissionReport = listOfSalesReports.Where(x => x.Id == id).ToList();
            ;
            return View(_userSaleReportViewModel);
        }
    }
}