using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.ModelServices
{
    public interface ISalesPerson
    {
        string Id { get; set; }

        string UserName { get; set; }

        double TotalCommission { get; set; }

    }
}
