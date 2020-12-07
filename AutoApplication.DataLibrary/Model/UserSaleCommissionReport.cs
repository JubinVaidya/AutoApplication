using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class UserSaleCommissionReport : IUserSaleCommissionReport
    {
        public string Id { get; set; }
        public int AutoId { get; set; }
        public double CommissionPercent { get; set; }
        public double SalesAmount { get; set; }
        public DateTime SalesDate { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string AutoMakerName { get; set; }
        public string AutoModelName { get; set; }
        public int AutoModelYear { get; set; }
        [Display(Name = "Commission Amount")]
        public double CommissionAmount { get; set; }
    }
}
