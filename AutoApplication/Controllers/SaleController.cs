using AutoApplication.DataLibrary.BusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic.SaleBusinessLogic;

using AutoApplication.DataLibrary.Model;
using AutoApplication.DataLibrary.ModelServices;
using AutoApplication.Resources;
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
            _autoSalesViewModel.ListStateNames = Enum.GetValues(typeof(StateNames)).Cast<StateNames>();
            return View(_autoSalesViewModel);
        }

        public ActionResult Create(AutoSalesViewModel autoSaleObj)
        {
            return View(autoSaleObj);
        }


        [HttpPost]
        public async Task<ActionResult> CreateSale(AutoSalesViewModel autoSaleObj)
        {
            try
            {
                var isCustomerValid = SimpleValidator.Validate(autoSaleObj.Customer);
                var isPaymentValid = SimpleValidator.Validate(autoSaleObj.Payment);

                if (!(isCustomerValid.IsValid && isPaymentValid.IsValid))
                {
                    autoSaleObj.Auto = await _autoDataProcessor.FindAutoAsync(autoSaleObj.Auto.AutoID);
                    autoSaleObj.ListStateNames = Enum.GetValues(typeof(StateNames)).Cast<StateNames>();
                    return View("Create", autoSaleObj);
                }

                //store Customer Information
                int custId = await StoreCustomerInformation(autoSaleObj);

                //store payment Information
                int paymentId = 0;
                if (custId != 0)
                    paymentId = await StorePaymentInformation(autoSaleObj);

                // Store Sales Data
                if (paymentId != 0)
                    await StoreSalesData(autoSaleObj, custId, paymentId);

                autoSaleObj.ListStateNames = Enum.GetValues(typeof(StateNames)).Cast<StateNames>();

                ViewBag.title = "<p>Success</p>";
                ViewBag.msg = "<p> Sales completed. </p>";
                return View("Create", autoSaleObj);
            }
            catch (Exception ex)
            {
                autoSaleObj.ListStateNames = Enum.GetValues(typeof(StateNames)).Cast<StateNames>();
                ViewBag.title = "<p>Error!</p>";
                ViewBag.msg = "<p> Please try again later. </p>";
                return View("Create", autoSaleObj);
            }

        }

        private async Task StoreSalesData(AutoSalesViewModel autoSaleObj, int custId, int paymentId)
        {
            int saleId = 1;
            var highestSaleId = await _salesDataProcessor.GetHighestSaleId();

            if (highestSaleId != 0)
                saleId = highestSaleId + saleId;

            autoSaleObj.Sale = new Sale();

            autoSaleObj.Sale.SaleID = saleId;
            autoSaleObj.Sale.AutoId = autoSaleObj.Auto.AutoID;
            autoSaleObj.Sale.SalesAmount = (float)autoSaleObj.Auto.AutoListedPrice;
            autoSaleObj.Sale.UserId = User.Identity.GetUserId();
            autoSaleObj.Sale.SalesDate = DateTime.Now;

            autoSaleObj.Sale.PaymentID = paymentId;
            autoSaleObj.Sale.PaymentNameOnCard = autoSaleObj.Payment.PaymentNameOnCard;
            autoSaleObj.Sale.PaymentCardNumber = autoSaleObj.Payment.PaymentCardNumber;
            autoSaleObj.Sale.PaymentCardExpiryDate = autoSaleObj.Payment.PaymentCardExpiryDate;
            autoSaleObj.Sale.PaymentSecurityCode = autoSaleObj.Payment.PaymentSecurityCode;

            autoSaleObj.Sale.CustomerID = custId;
            autoSaleObj.Sale.CustomerFirstName = autoSaleObj.Customer.CustomerFirstName;
            autoSaleObj.Sale.CustomerLastName = autoSaleObj.Customer.CustomerLastName;
            autoSaleObj.Sale.CustomerStreetAddress = autoSaleObj.Customer.CustomerStreetAddress;
            autoSaleObj.Sale.CustomerSuiteNumber = autoSaleObj.Customer.CustomerSuiteNumber;
            autoSaleObj.Sale.CustomerCity = autoSaleObj.Customer.CustomerCity;
            autoSaleObj.Sale.CustomerState = autoSaleObj.Customer.CustomerState;;
            autoSaleObj.Sale.CustomerZipCode = autoSaleObj.Customer.CustomerZipCode;
            autoSaleObj.Sale.CustomerPhoneNumber = autoSaleObj.Customer.CustomerPhoneNumber;

            await _salesDataProcessor.StoreSaleDataAsync(autoSaleObj.Sale);


        }

        private async Task<int> StorePaymentInformation(AutoSalesViewModel autoSaleObj)
        {
            try
            {
                int paymentId = 1;
                int highestPaymentId = await _salesDataProcessor.GetHighestPaymentId();
                if (highestPaymentId != 0)
                    paymentId = highestPaymentId + paymentId;
                _autoSalesViewModel.Payment = autoSaleObj.Payment;
                _autoSalesViewModel.Payment.PaymentID = paymentId;
                return paymentId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private async Task<int> StoreCustomerInformation(AutoSalesViewModel autoSaleObj)
        {
            try
            {
                int custId = 1;
                var highestCustId = await _salesDataProcessor.GetHighestCustomerId();
                if (highestCustId != 0)
                    custId = highestCustId + custId;
                _autoSalesViewModel.Customer = autoSaleObj.Customer;
                _autoSalesViewModel.Customer.CustomerID = custId;
                return custId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}