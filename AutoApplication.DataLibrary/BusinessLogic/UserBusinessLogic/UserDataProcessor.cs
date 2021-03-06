﻿using AutoApplication.DataLibrary.DataAccessServices;
using AutoApplication.DataLibrary.Model;
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

        public IList<Roles> FindAllRole()
        {
            string sql = UserStoredProceduresNames.GetAllRole;
            return _sqlServerFindData.FindData<Roles>(sql);
        }

        public IList<SalesPerson> FindAllSalesPeople()
        {
            string sql = UserStoredProceduresNames.GetAllSalesPeople;
            return _sqlServerFindData.FindData<SalesPerson>(sql);
        }


        public IList<string> FindUserRole(string userName)
        {
            string sql = UserStoredProceduresNames.GetRoleOfLoggedInUser;
            return _sqlServerFindData.FindData<string>(sql) ;
        }



    }
}
