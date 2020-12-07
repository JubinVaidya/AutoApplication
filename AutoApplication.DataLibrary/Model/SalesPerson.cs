using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class SalesPerson : ISalesPerson
    {
        public string Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Display(Name = "Total Commission")]
        public double TotalCommission { get; set; }
    }
}
