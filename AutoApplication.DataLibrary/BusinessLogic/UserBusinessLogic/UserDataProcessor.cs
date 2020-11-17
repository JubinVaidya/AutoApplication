using AutoApplication.DataLibrary.DataAccessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.UserBusinessLogic
{
    public class UserDataProcessor: IUserDataProcessor
    {
        ISqlServerFindData _sqlServerFindData;

        public UserDataProcessor(ISqlServerFindData sqlServerFindData)
        {
            _sqlServerFindData = sqlServerFindData;
        }

        public IList<string> FindUserRole(string userName)
        {
            string sql = UserStoredProceduresNames.GetRoleOfLoggedInUser;
            return _sqlServerFindData.FindData<string>(sql) ;
        }

    }
}
