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

namespace AutoApplication.Controllers
{
    public class AutoController : Controller
    {
        IAuto _auto;
        IList<Auto> _listOfAutos;
        public AutoController(IAuto auto, IList<Auto> listOfAutos)
        {
            _auto = auto;
            _listOfAutos = listOfAutos;
        }

        /// <summary>
        /// This Method will query the database for all autos and display it in the view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data =AutoDataProcessor.LoadAutos();
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