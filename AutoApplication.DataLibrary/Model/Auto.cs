using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class Auto : IAuto
    {

        public int AutoID { get; set; }
        [Required]
        [Display(Name ="Model Name")]
        public string AutoModelName { get; set; }
        [Required]
        [Display(Name = "Maker Name")]
        public string AutoMakerName { get; set; }
        [Required]
        [Display(Name = "Model Year")]
        public string AutoModelYear { get; set; }
        [Required]
        [Display(Name = "Auto Usage Status")]
        public string AutoUsageStatus { get; set; }
        [Required]
        [Display(Name = "Auto List Price")]
        public double AutoListedPrice { get; set; }
        public string AutoVinNumber { get; set; }
        public bool AutoInStock { get; set; }
        public double AutoMilesTravelled { get; set; }
    }
}
