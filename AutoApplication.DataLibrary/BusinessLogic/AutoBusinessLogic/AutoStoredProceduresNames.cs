using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic
{
    public static class AutoStoredProceduresNames
    {
        public static string GetAllAutos { get { return "dbo.spAutos_GetAll"; } }
        public static string QueryForHighestAutoID { get { return "dbo.spAutoGetHighestAutoId"; } }
        public static string GetAutoByID { get { return "dbo.spAutos_GetAutoByID @AutoID"; } }
        public static string QueryToSaveAuto { get { return "dbo.spAutoStoreNewAutoInformation @AutoID,@AutoMakerName,@AutoModelName,@AutoModelYear,@AutoUsageStatus,@AutoMilesTravelled,@AutoListedPrice,@AutoVinNumber,@AutoInStock"; } }

        public static string QueryToUpdateAuto { get { return "dbo.spAutoUpdateAuto @AutoID,@AutoMakerName,@AutoModelName,@AutoModelYear,@AutoUsageStatus,@AutoMilesTravelled,@AutoListedPrice,@AutoVinNumber,@AutoInStock"; } }
    }
}