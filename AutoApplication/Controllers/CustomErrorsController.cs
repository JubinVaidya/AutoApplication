﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoApplication.Controllers
{
    public class CustomErrorsController : Controller
    {
        // GET: CustomErrors
        public ActionResult Index()
        {
            return View();
        }

        [Route("CustomErrors/Error404")]
        public ActionResult Error404()
        {
            return View();
        }


        public ActionResult ErrorInput()
        {
            return View();
        }
    }
}