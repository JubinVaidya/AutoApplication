using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.UserBusinessLogic
{
    public static class UserStoredProceduresNames
    {

        public static string GetRoleOfLoggedInUser { get { return "dbo.spGetRolesOfUserWhoLoggedIn @UserRoleName"; } }
        public static string GetAllRole { get { return "dbo.spRoles_GetAllRoles"; } }
        public static string GetAllSalesPeople { get { return "dbo.spUsers_GetAllSalesPeople"; } }
    }
}
