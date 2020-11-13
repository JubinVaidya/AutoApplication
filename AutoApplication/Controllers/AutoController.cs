using System.Collections.Generic;
using System.Web.Mvc;
using AutoApplication.DataLibrary.BusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.Model;

namespace AutoApplication.Controllers
{
    public class AutoController : Controller
    {
        IAutoDataProcessor _autoDataProcessor;
        List<Auto> _listOfAutos;

        public AutoController(IAutoDataProcessor autoDataProcessor)
        {
            _autoDataProcessor = autoDataProcessor;
            _listOfAutos = new List<Auto>();
        }


        /// <summary>
        /// This Method will query the database for all autos and display it in the view.
        /// </summary>
        /// <returns></returns>
        /// 

        public ActionResult Index()
        {

            var data = _autoDataProcessor.LoadAutos();
            foreach (var auto in data)
            {
                _listOfAutos.Add(new Auto
                {
                    AutoID = auto.AutoID,
                    AutoMakerName = auto.AutoMakerName,
                    AutoModelName = auto.AutoModelName,
                    AutoModelYear = auto.AutoModelYear,
                    AutoListedPrice = auto.AutoListedPrice,
                    AutoUsageStatus = auto.AutoUsageStatus,
                    AutoVinNumber = auto.AutoVinNumber
                });
            }

            if (User.IsInRole(CompanyRoles.AdminRole))
                return View("AdminIndex", _listOfAutos);
            else
                return View("EmployeeIndex", _listOfAutos);

        }

    }
}