using AutoApplication.Models;
using AutoApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoApplication.DataLibrary;
using AutoApplication.DataLibrary.DataAccess;
using AutoApplication.DataLibrary.BusinessLogic;
using AutoApplication.DataLibrary.DataAccessServices;
using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;

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
        public ActionResult Index()
        {
            var data = _autoDataProcessor.LoadAutos();
            foreach(var auto in data)
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


            return View(_listOfAutos);
        }

        



    }
}