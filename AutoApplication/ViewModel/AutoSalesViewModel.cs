using AutoApplication.DataLibrary.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoApplication.ViewModel
{
    public class AutoSalesViewModel 
    {
       public IAuto Auto;
        public ICustomer Customer;
        public ISale Sale;

        public AutoSalesViewModel(IAuto auto, ICustomer customer, ISale sale)
        {
            Auto = auto;
            Customer = customer;
            Sale = sale;
        }


    }
}