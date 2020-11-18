using AutoApplication.DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.SaleBusinessLogic
{
    public  interface ISalesDataProcessor
    {
        Task<int> StoreCustomerDataAsync(Customer custObj);
        Task<int> StorePaymentDataAsync(Payment paymentObj);
        Task<int> StoreSaleDataAsync(Sale saleObj);
        Task<int> GetHighestCustomerId();
        Task<int> GetHighestPaymentId();
        Task<int> GetHighestSaleId();


    }
}
