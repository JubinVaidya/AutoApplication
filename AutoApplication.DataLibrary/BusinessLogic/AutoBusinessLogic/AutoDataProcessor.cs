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

        public AutoDataProcessor(ISqlServerFindData sqlServerFindData)
        {
            _sqlServerFindData = sqlServerFindData;
        }

        //public static int AddAuto(int autoId, string autoMaker, string autoModelName, string autoModelYear)
        //{
        //    Auto data = new Auto
        //    {
        //        AutoID = autoId,
        //        AutoMakerName = autoMaker,
        //        AutoModelName = autoModelName,
        //        AutoModelYear = autoModelYear
        //    };
        //    string sql = @"insert into dbo.Autos (AutoID, AutoMakerName, AutoModelName, AutoModelYear) 
        //                   values (@AutoID, @AutoMakerName, @AutoModelName, @AutoModelYear)";
        //    return SqlServerFindData.SaveData(sql, data);
        //}

        public IList<Auto> LoadAutos()
        {
            string sql = AutoStoredProceduresNames.GetAllAutos;
            return _sqlServerFindData.FindData<Auto>(sql);
        }

    }
}
