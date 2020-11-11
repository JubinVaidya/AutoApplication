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

        public AutoController(IAuto auto)
        {
            _auto = auto;
        }

        // GET: Auto
        public ActionResult Index()
        {
            _auto.AutoID = 101;
            _auto.AutoMaker = "Toyota";
            _auto.AutoModelName = "Camry";
            _auto.AutoModelYear = "2010";

            //trying in dummy data
            var k  = AutoDataProcessor.LoadAutos();
            ;



            return View(_auto);
        }




    }
}