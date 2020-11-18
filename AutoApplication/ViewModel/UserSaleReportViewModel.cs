using AutoApplication.DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoApplication.ViewModel
{
    public class UserSaleReportViewModel
    {
        public SalesPerson SalePerson { get; set; }
        public List<UserSaleCommissionReport> UserSaleCommissionReport{get; set ;}

    }
}