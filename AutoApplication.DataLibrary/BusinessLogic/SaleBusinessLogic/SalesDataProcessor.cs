using AutoApplication.DataLibrary.DataAccess;
using AutoApplication.DataLibrary.DataAccessServices;
using AutoApplication.DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.SaleBusinessLogic
{
    public class SalesDataProcessor : ISalesDataProcessor
    {

        ISqlServerDataModification _sqlServerDataModification;
        ISqlServerFindData _sqlServerFindData;

        public SalesDataProcessor(ISqlServerDataModification sqlServerDataModification, ISqlServerFindData sqlServerFindData)
        {
            _sqlServerDataModification = sqlServerDataModification;
            _sqlServerFindData = sqlServerFindData;
        }


        public async Task<int> GetHighestCustomerId()
        {
            string sql = SaleStoredProcedureNames.GetHighestCustomerID;

            return await Task.Run(() => _sqlServerFindData.FindData(sql));

        }
        public async Task<int> GetHighestPaymentId()
        {
            string sql = SaleStoredProcedureNames.GetHighestPaymentID;

            return await Task.Run(() => _sqlServerFindData.FindData(sql));
        }

        public async Task<int> GetHighestSaleId()
        {
            string sql = SaleStoredProcedureNames.GetHighestSaleID;

            return await Task.Run(() => _sqlServerFindData.FindData(sql));
        }

        public async Task<int> StoreCustomerDataAsync(Customer custObj)
        {
            string sql = SaleStoredProcedureNames.StoreCustomerInformation;

            return await Task.Run(() => _sqlServerDataModification.SaveData<Customer>(sql, custObj));
        }

        public async Task<int> StorePaymentDataAsync(Payment paymentObj)
        {
            string sql = SaleStoredProcedureNames.StorePaymentInformation;

            return await Task.Run(() => _sqlServerDataModification.SaveData<Payment>(sql, paymentObj));
        }

        public async Task<int> StoreSaleDataAsync(Sale saleObj)
        {
            string sql = SaleStoredProcedureNames.StoreSaleInformation;

            return await Task.Run(() => _sqlServerDataModification.SaveData<Sale>(sql, saleObj)); ; ;
        }
    }
}
