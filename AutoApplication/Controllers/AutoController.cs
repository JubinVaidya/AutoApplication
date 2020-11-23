using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoApplication.DataLibrary.Model;
using AutoApplication.Models;
using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic;
using Microsoft.AspNet.Identity;

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
        [HttpGet]
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

        // GET: Auto/Create
        public ActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

        // POST: Auto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAuto(Auto auto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", auto);
            }
            try
            {
                var highestAutoId = await _autoDataProcessor.GetHighestAutoId();
                auto.AutoID = highestAutoId != 0 ? highestAutoId + 1 : 1000;
                auto.AutoInStock = true;
                await _autoDataProcessor.SaveAutoAsync(auto);
                return View(auto);
            }
            catch (Exception ex)
            {
                //there was an error we need to log here.
            }

            if (User.IsInRole(CompanyRoles.AdminRole))
                return View("AdminIndex", _listOfAutos);
            else
                return View("EmployeeIndex", _listOfAutos);
        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Auto auto = await _autoDataProcessor.FindAutoAsync(id);
            auto.AutoInStockString = auto.AutoInStock ? "Available" : "Out Of Stock";
            if (auto == null)
                return HttpNotFound();

            if (User.IsInRole(CompanyRoles.AdminRole))
                return View("AdminAutoDetails", auto);
            else
                return View("EmployeeAutoDetails", auto);
        }



        // GET: Auto/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Auto auto = await _autoDataProcessor.FindAutoAsync(id);

            if (User.IsInRole(CompanyRoles.AdminRole))
                return View("Edit", auto);
            else
            {
                //put a pop-up that says you dont have enough permission
                //and go back to home page.
            }

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Auto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Auto auto)
        {
            try
            {
                //try to update
                await _autoDataProcessor.UpdateAutoAsync(auto);

            }
            catch (Exception)
            {
                //log error
                //Display popup if possible.
            }

            return View(auto);
        }


        public ActionResult EditSuccessPopup()
        {
            return View();
        }

    }
}
