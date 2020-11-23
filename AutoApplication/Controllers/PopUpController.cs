using AutoApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoApplication.Controllers
{
    public class PopUpController : Controller
    {
        // GET: PopUp
        public ActionResult Index()
        {
            return View();
        }
        [Route("PopUpController")]
        public ActionResult PopUpSuccess()
        {
            PopupModel model = new PopupModel();

                model.ShowDialog = true;

            return View(model);
        }
    }
}