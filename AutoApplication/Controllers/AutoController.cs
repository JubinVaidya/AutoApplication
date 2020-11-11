using AutoApplication.Models;
using AutoApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            //trying in dummy data
            _auto.AutoID = 101;
            _auto.AutoMaker = "Toyota";
            _auto.AutoModelName = "Camry";
            _auto.AutoModelYear = "2010";

            return View(_auto);
        }




    }
}