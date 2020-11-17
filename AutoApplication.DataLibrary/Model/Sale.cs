using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.Model
{
    public class Sale : ISale
    {
        public int SaleId { get; set; }
        public int AutoId { get; set; }
        public string UserId { get; set; }
        public int CustomerID { get; set; }
        public int SalesAmount { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
