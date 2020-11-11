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
         string AutoMakerName { get; set; }
         string AutoModelYear { get; set; }
         string AutoUsageStatus { get; set; }
         double AutoListedPrice { get; set; }
         string AutoVinNumber { get; set; }
    }
}
