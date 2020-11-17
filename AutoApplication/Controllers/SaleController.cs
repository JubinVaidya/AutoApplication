using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.Model;
using AutoApplication.DataLibrary.ModelServices;
using AutoApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoApplication.Controllers
{
    public class SaleController : Controller
    {
        AutoSalesViewModel _autoSalesViewModel;
        IAutoDataProcessor _autoDataProcessor;


        public SaleController(AutoSalesViewModel autoSalesViewModel, IAutoDataProcessor autoDataProcessor)
        {
            _autoSalesViewModel = autoSalesViewModel;
            _autoDataProcessor = autoDataProcessor;
        }

        // GET: Sale
        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            IList<Auto> listAuto = await _autoDataProcessor.FindAutoAsync(id);
            _autoSalesViewModel.Auto = listAuto.FirstOrDefault();


            return View(_autoSalesViewModel);
        }
    }
}