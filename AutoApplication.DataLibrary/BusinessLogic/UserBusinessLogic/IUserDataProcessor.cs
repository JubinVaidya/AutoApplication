using System;
using System.Collections.Generic;
using AutoApplication.DataLibrary.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.UserBusinessLogic
{
    public interface IUserDataProcessor
    {
        IList<string> FindUserRole(string userName);
        IList<Roles> FindAllRole();
        IList<SalesPerson> FindAllSalesPeople();

    }
}
