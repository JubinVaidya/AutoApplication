
using AutoApplication.DataLibrary.DataAccessServices;
using AutoApplication.DataLibrary.Model;
using System.Collections.Generic;

namespace AutoApplication.DataLibrary.BusinessLogic.ReportBusinessLogic
{
    public class ReportDataProcessor : IReportDataProcessor
    {
        ISqlServerFindData _sqlServerFindData;

        public ReportDataProcessor(ISqlServerFindData sqlServerFindData)
        {
            _sqlServerFindData = sqlServerFindData;
        }
        public IList<UserSaleCommissionReport> LoadUserCommissionReport()
        {
            string sql = ReportStoredProceduresNames.GetUserSaleReport;
            return _sqlServerFindData.FindData<UserSaleCommissionReport>(sql);
        }
    }
}
