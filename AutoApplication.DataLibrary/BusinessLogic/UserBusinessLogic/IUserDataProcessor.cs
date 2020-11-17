using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.UserBusinessLogic
{
    public interface IUserDataProcessor
    {
        IList<string> FindUserRole(string userName);
    }
}
