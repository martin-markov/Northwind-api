using Northwind.UI.Models;
using Northwind.UI.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Northwind.UI.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService customersService;
        public HomeController()
        {
            this.customersService = new CustomersService();
        }

        public HomeController(ICustomerService customerService)
        {
            this.customersService = customerService;
        }

        public async Task<ActionResult> Index(string customerName = "")
        {
            CustomerListViewModel model = await this.customersService.GetCustomers(customerName);
            return View(model);
        }

        public async Task<ActionResult> Details(string customerID)
        {
            CustomerViewModel model = await this.customersService.GetCustomerDetails(customerID);
            if (model == null || model.CustomerInfo == null)
                return HttpNotFound();
            return View(model);
        }


    }
}
