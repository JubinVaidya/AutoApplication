using AutoApplication.DataLibrary.Model;
using AutoApplication.DataLibrary.BusinessLogic;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoApplication.ViewModel
{
    public class AutoSalesViewModel
    {
        public Auto Auto { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public Sale Sale { get; set; }
        public IEnumerable<StateNames> ListStateNames{get;set;}
    }
}