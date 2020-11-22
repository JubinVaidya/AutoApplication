using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic.SaleBusinessLogic;

using AutoApplication.DataLibrary.Model;
using AutoApplication.DataLibrary.ModelServices;
using AutoApplication.ViewModel;
using Microsoft.AspNet.Identity;
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
        ISalesDataProcessor _salesDataProcessor;



        public SaleController(AutoSalesViewModel autoSalesViewModel, IAutoDataProcessor autoDataProcessor, ISalesDataProcessor salesDataProcessor)
        {
            _autoSalesViewModel = autoSalesViewModel;
            _autoDataProcessor = autoDataProcessor;
            _salesDataProcessor = salesDataProcessor;
        }

        // GET: Sale
        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            _autoSalesViewModel.Auto = await _autoDataProcessor.FindAutoAsync(id);


            return View(_autoSalesViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> CreateSale(AutoSalesViewModel autoSaleObj)
        {
            #region
            int custId = 1;
            var highestCustId = await _salesDataProcessor.GetHighestCustomerId();
            if (highestCustId != 0)
                custId = highestCustId + custId;
            _autoSalesViewModel.Customer = autoSaleObj.Customer;
            _autoSalesViewModel.Customer.CustomerID = custId;
            //push data to database
            await _salesDataProcessor.StoreCustomerDataAsync(_autoSalesViewModel.Customer);
            #endregion

            #region
            int paymentId = 1;
            int highestPaymentId = await _salesDataProcessor.GetHighestPaymentId();
            if (highestPaymentId != 0)
                paymentId = highestPaymentId + paymentId;
            _autoSalesViewModel.Payment = autoSaleObj.Payment;
            _autoSalesViewModel.Payment.PaymentID = paymentId;
            await _salesDataProcessor.StorePaymentDataAsync(_autoSalesViewModel.Payment);
            #endregion

            #region Store Sales Data
            int saleId = 1;
            var highestSaleId = await _salesDataProcessor.GetHighestSaleId();

            if (highestSaleId != 0)
                saleId = highestSaleId + saleId;

            autoSaleObj.Sale = new Sale();


            autoSaleObj.Sale.SaleID = saleId;
            autoSaleObj.Sale.AutoId = autoSaleObj.Auto.AutoID;
            autoSaleObj.Sale.SalesAmount = (float)autoSaleObj.Auto.AutoListedPrice;
            autoSaleObj.Sale.PaymentID = paymentId;
            autoSaleObj.Sale.CustomerID = custId;
            autoSaleObj.Sale.UserId = User.Identity.GetUserId();
            autoSaleObj.Sale.SalesDate = DateTime.Now;
            await _salesDataProcessor.StoreSaleDataAsync(autoSaleObj.Sale); 
            #endregion
            return View(_autoSalesViewModel);
        }

  
    }
}