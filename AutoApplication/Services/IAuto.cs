using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.Services
{
    public interface IAuto
    {
        int AutoID { get; set; }
        string AutoModelName { get; set; }
        string AutoMaker { get; set; }
        string AutoModelYear { get; set; }
    }
}
