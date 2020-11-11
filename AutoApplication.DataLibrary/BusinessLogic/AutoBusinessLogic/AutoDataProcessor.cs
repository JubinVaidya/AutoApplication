using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.DataAccess;
using AutoApplication.DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic
{
    public static class AutoDataProcessor
    {
        public static int AddAuto(int autoId, string autoMaker, string autoModelName, string autoModelYear)
        {
            Auto data = new Auto
            {
                AutoID = autoId,
                AutoMaker = autoMaker,
                AutoModelName = autoModelName,
                AutoModelYear = autoModelYear
            };
            string sql = @"insert into dbo.Autos (AutoID, AutoMaker, AutoModelName, AutoModelYear) 
                           values (@AutoID, @AutoMaker, @AutoModelName, @AutoModelYear)";
            return SqlServerDataAccess.SaveData(sql, data);
        }

        public static List<Auto> LoadAutos()
        {
            string sql = AutoStoredProceduresNames.GetAllAutos;
            return SqlServerDataAccess.LoadData<Auto>(sql).ToList();
        }

    }
}
