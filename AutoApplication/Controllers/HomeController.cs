using AutoApplication.DataLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole(CompanyRoles.AdminRole))
            {
                return View("AdminHomeView");
            }
            else
            {
                return View("EmployeeHomeView");
            }
        }

    }
}