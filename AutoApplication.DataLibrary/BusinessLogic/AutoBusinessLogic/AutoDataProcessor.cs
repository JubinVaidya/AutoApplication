using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.DataAccess;
using AutoApplication.DataLibrary.DataAccessServices;
using AutoApplication.DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic
{
    public class AutoDataProcessor : IAutoDataProcessor
    {
        ISqlServerFindData _sqlServerFindData;
        ISqlServerDataModification _sqlServerDataModification;

        public AutoDataProcessor(ISqlServerFindData sqlServerFindData, ISqlServerDataModification sqlServerDataModification)
        {
            _sqlServerFindData = sqlServerFindData;
            _sqlServerDataModification = sqlServerDataModification;
        }

        public async Task<Auto> FindAutoAsync(int id)
        {
            string sql = AutoStoredProceduresNames.GetAutoByID;
            return await Task.Run(() => _sqlServerFindData?.FindData<Auto>(sql, id).FirstOrDefault());
        }

        public async Task<int> GetHighestAutoId()
        {
            string sql = AutoStoredProceduresNames.QueryForHighestAutoID;
            return await Task.Run(() => _sqlServerFindData.FindData(sql));
        }


        public IList<Auto> LoadAutos()
        {
            string sql = AutoStoredProceduresNames.GetAllAutos;
            return _sqlServerFindData.FindData<Auto>(sql);
        }

        public async Task<int> SaveAutoAsync(Auto auto)
        {
            string sql = AutoStoredProceduresNames.QueryToSaveAuto;
            return await Task.Run(() => _sqlServerDataModification.SaveData(sql,auto));
        }

        public async Task<int> UpdateAutoAsync(Auto auto)
        {
            string sql = AutoStoredProceduresNames.QueryToUpdateAuto;
            return await Task.Run(() => _sqlServerDataModification.UpdateData(sql, auto));
        }
    }
}
