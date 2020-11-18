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

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {

            IList<Auto> listAuto = await _autoDataProcessor.FindAutoAsync(id);

            Auto auto = listAuto.FirstOrDefault();

            if (auto == null)
            {
                return HttpNotFound();
            }

            return View(auto);
        }


        //// GET: Auto/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Auto auto = await db.Autoes.FindAsync(id);
        //    if (auto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(auto);
        //}

        //// GET: Auto/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Auto/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "AutoID,AutoModelName,AutoMakerName,AutoModelYear,AutoUsageStatus,AutoListedPrice,AutoVinNumber")] Auto auto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Autoes.Add(auto);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(auto);
        //}

        //// GET: Auto/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Auto auto = await db.Autoes.FindAsync(id);
        //    if (auto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(auto);
        //}

        //// POST: Auto/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "AutoID,AutoModelName,AutoMakerName,AutoModelYear,AutoUsageStatus,AutoListedPrice,AutoVinNumber")] Auto auto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(auto).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(auto);
        //}

        //// GET: Auto/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Auto auto = await db.Autoes.FindAsync(id);
        //    if (auto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(auto);
        //}

        //// POST: Auto/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Auto auto = await db.Autoes.FindAsync(id);
        //    db.Autoes.Remove(auto);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
