using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Northwind.DTO;
using Northwind.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace Northwind.UI.Services
{
    public class CustomersService
    {
        public async Task<CustomerListViewModel> GetCustomers(string customerName)
        {
            CustomerListViewModel vm = new CustomerListViewModel();
            string host = "http://localhost:2100/";

            using(var apiService = new RestApiService(host, "application/json"))
            {
                string data = await apiService.GetJsonAsync("api/Customers");
                vm.Customers = JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(data);
            }
            if(!String.IsNullOrEmpty(customerName))
            {
                vm.Customers = vm.Customers.Where(c => c.ContactName.Contains(customerName));
            }
            return vm;
        }

        public async Task<CustomerViewModel> GetCustomerDetails(string customerID)
        {
            CustomerViewModel vm = new CustomerViewModel();
            string host = "http://localhost:2100/";

            string infoEndpoint = String.Format("api/Customers/{0}", customerID);
            string orderEndpoint = String.Concat(infoEndpoint,"/Orders");
            using(var apiService = new RestApiService(host, "application/json"))
            {
                string customerData = await apiService.GetJsonAsync(infoEndpoint);
                vm.CustomerInfo = JsonConvert.DeserializeObject<CustomerDTO>(customerData);
                string orderData = await apiService.GetJsonAsync(orderEndpoint);
                vm.CustomerOrders = JsonConvert.DeserializeObject<IEnumerable<OrderDTO>>(orderData);
            }
            
            return vm;
        }
    }
}