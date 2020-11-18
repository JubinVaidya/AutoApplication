using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class SalesPerson : ISalesPerson
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public double TotalCommission { get; set; }
    }
}
