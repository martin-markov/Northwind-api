using Northwind.UI.Models;
using Northwind.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Northwind.UI.Controllers
{
    public class HomeController : Controller
    {
        private CustomersService _customersService;
        public CustomersService CustomersService
        {
            get
            {
                if (_customersService == null)
                    _customersService = new CustomersService();
                return _customersService;
            }
        }

        public async Task<ActionResult> Index(string customerName = "")
        {
            CustomerListViewModel model = await this.CustomersService.GetCustomers(customerName);
            return View(model);
        }

        public async Task<ActionResult> Details(string customerID)
        {
            if (String.IsNullOrEmpty(customerID))
                HttpNotFound();

            CustomerViewModel model = await this.CustomersService.GetCustomerDetails(customerID);
            return View(model);
        }


    }
}
