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
using PagedList;
using System.Diagnostics;

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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            try
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.AutoMakerNameSortParm = String.IsNullOrEmpty(sortOrder) ? "maker_desc" : "";
                ViewBag.AutoModelNameSortParm = sortOrder == "model_asc" ? "model_dsc" : "model_asc";
                ViewBag.AutoYearNameSortParm = sortOrder == "model_yr_asc" ? "model_yr_dsc" : "model_yr_asc";
                ViewBag.AutoListPriceSortParm = sortOrder == "model_price_asc" ? "model_price_dec" : "model_price_asc";
                ViewBag.AutoUsageSortParm = sortOrder == "model_usage_asc" ? "model_usage_dsc" : "model_usage_asc";
                ViewBag.AutoVinSortParm = sortOrder == "model_vin_asc" ? "model_vin_dsc" : "model_vin_asc";

                _listOfAutos = _autoDataProcessor.LoadAutos().ToList();

                if (searchString != null)
                    page = 1;
                else
                    searchString = currentFilter;

                ViewBag.CurrentFilter = searchString;

                //search a list based on search string
                _listOfAutos = SelectListBySearchString(_listOfAutos, searchString?.ToLower());

                //Sort the list of autos by given parameter field
                _listOfAutos = SortArrayBySortParm(_listOfAutos, sortOrder);

                int pageSize = Configs.ItemsInAPage;
                int pageNumber = (page ?? 1);
                if (User.IsInRole(CompanyRoles.AdminRole))
                    return View("AdminIndex", _listOfAutos.ToPagedList(pageNumber, pageSize));
                else
                    return View("EmployeeIndex", _listOfAutos.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AutoController: Index threw an error", ex.ToString());
                return RedirectToAction("Error404", "CustomErrors");
            }
        }

        private List<Auto> SelectListBySearchString(List<Auto> listOfAutos, string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                listOfAutos = listOfAutos.Where(s =>
                    s.AutoMakerName.ToLower().Contains(searchString) ||
                    s.AutoModelName.ToLower().Contains(searchString) ||
                    s.AutoModelYear.ToLower().Contains(searchString) ||
                    s.AutoListedPrice.ToString().ToLower().Contains(searchString) ||
                    s.AutoUsageStatus.ToString().ToLower().Contains(searchString) ||
                    s.AutoVinNumber.ToLower().Contains(searchString)
                    ).ToList();
            }
            return listOfAutos;
        }

        private List<Auto> SortArrayBySortParm(List<Auto> listOfAutos, string sortOrder)
        {
            switch (sortOrder)
            {
                case "model_vin_asc":
                    listOfAutos = listOfAutos.OrderBy(s => s.AutoVinNumber).ToList();
                    break;
                case "model_vin_dsc":
                    listOfAutos = listOfAutos.OrderByDescending(s => s.AutoVinNumber).ToList();
                    break;
                case "model_price_asc":
                    listOfAutos = listOfAutos.OrderBy(s => s.AutoListedPrice).ToList();
                    break;
                case "model_price_dec":
                    listOfAutos = listOfAutos.OrderByDescending(s => s.AutoListedPrice).ToList();
                    break;
                case "model_usage_asc":
                    listOfAutos = listOfAutos.OrderBy(s => s.AutoUsageStatus).ToList();
                    break;
                case "model_usage_dsc":
                    listOfAutos = listOfAutos.OrderByDescending(s => s.AutoUsageStatus).ToList();
                    break;
                case "model_yr_asc":
                    listOfAutos = listOfAutos.OrderBy(s => s.AutoModelYear).ToList();
                    break;
                case "model_yr_dsc":
                    listOfAutos = listOfAutos.OrderByDescending(s => s.AutoModelYear).ToList();
                    break;
                case "model_asc":
                    listOfAutos = listOfAutos.OrderBy(s => s.AutoModelName).ToList();
                    break;
                case "model_dsc":
                    listOfAutos = listOfAutos.OrderByDescending(s => s.AutoModelName).ToList();
                    break;
                case "maker_desc":
                    listOfAutos = listOfAutos.OrderByDescending(s => s.AutoMakerName).ToList();
                    break;
                default:  // Name ascending 
                    listOfAutos = listOfAutos.OrderBy(s => s.AutoMakerName).ToList();
                    break;
            }

            return listOfAutos;
        }


        // GET: Auto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAuto(Auto auto)
        {
            if (!ModelState.IsValid)
                return View("Create", auto);

            try
            {
                var highestAutoId = await _autoDataProcessor.GetHighestAutoId();
                auto.AutoID = highestAutoId != 0 ? highestAutoId + 1 : 1000;
                auto.AutoInStock = true;
                await _autoDataProcessor.SaveAutoAsync(auto);
                return View("CreateSuccess");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AutoController: CreateAuto threw an error", ex.ToString());
                return RedirectToAction("Error404", "CustomErrors");
            }
        }

        /// <summary>
        /// This method will redirect the user to either Admin Side or Employee Side Depending on Credentials.
        /// </summary>
        /// <param name="id">Takes in an id that is used to find the corresponding Auto.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                Auto auto = await _autoDataProcessor.FindAutoAsync(id);
                if (auto == null)
                    return RedirectToAction("Error404", "CustomErrors");

                auto.AutoInStockString = auto.AutoInStock ? "Available" : "Out Of Stock";


                if (User.IsInRole(CompanyRoles.AdminRole))
                    return View("AdminAutoDetails", auto);
                else
                    return View("EmployeeAutoDetails", auto);
            }
            catch (Exception)
            {

                throw;
            }
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
                if (User.IsInRole(CompanyRoles.AdminRole))
                {
                    if (!ModelState.IsValid)
                        return View("Edit", auto);
                }


                //try to update
                await _autoDataProcessor.UpdateAutoAsync(auto);
                return View("EditSuccess");

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
