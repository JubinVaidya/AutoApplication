using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class Auto : IAuto
    {
        public int AutoID { get; set; }
        public string AutoModelName { get; set; }
        public string AutoMakerName { get; set; }
        public string AutoModelYear { get; set; }
        public string AutoUsageStatus { get; set; }
        public double AutoListedPrice { get; set; }
        public string AutoVinNumber { get; set; }
    }
}
