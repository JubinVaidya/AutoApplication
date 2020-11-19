using AutoApplication.DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic
{
    public interface IAutoDataProcessor
    {
        IList<Auto> LoadAutos();
        Task<int> GetHighestAutoId();
        Task<Auto> FindAutoAsync(int id);
        Task<int> SaveAutoAsync(Auto auto);
    }
}
