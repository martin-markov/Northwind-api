using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Northwind.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Simple.OData.Client;


namespace Northwind.UI.Services
{
    public class CustomersService
    {
        private RestApiService _restService;
        public CustomersService()
        {
            _restService = new RestApiService();
        }

        public async Task<CustomerListViewModel> GetCustomers(string customerName)
        {
            CustomerListViewModel vm = new CustomerListViewModel();
            string host = "http://localhost:63927/odata";

            ODataClient client = new ODataClient(host);
            if (String.IsNullOrEmpty(customerName))
            {
                vm.Customers = await client.For<Customer>()
                    .Expand(x => x.Orders)
                    .Select(x => new { x.CustomerID, x.ContactName, Orders = x.Orders.Select(o => o.OrderID) })
                    .FindEntriesAsync();
            }
            else
            {
                vm.Customers = await client.For<Customer>()
                    .Expand(x => x.Orders)
                    .Select(x => new { x.CustomerID, x.ContactName, Orders = x.Orders.Select(o => o.OrderID) })
                    .Filter(x => x.ContactName.Contains(customerName))
                    .FindEntriesAsync();
            }
            //string host = "http://localhost:63927/";
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(host);
            //    string endPoint = "odata/Customers?$expand=Orders($select=OrderID)";
            //    if (!String.IsNullOrEmpty(customerName))
            //        endPoint = String.Concat(endPoint, String.Format("&$filter=contains(ContactName, '{0}')", customerName));
            //    HttpResponseMessage response = await client.GetAsync(endPoint).ConfigureAwait(false);
            //    string content = await response.Content.ReadAsStringAsync();
            //    //dynamic customers = JObject.Parse(content);
            //    vm.Customers = JsonConvert.DeserializeObject<ODataResponse<Customer>>(content).Value ?? Enumerable.Empty<Customer>();

            //}
            //vm.Customers = await client.For<Customer>().Expand(x=>x.Orders).Select(x=> new {x.CustomerID , x.ContactName, Orders = x.Orders.Select(o=>o.OrderID)}).FindEntriesAsync();

            return vm;
        }

        public async Task<CustomerViewModel> GetCustomerDetails(string customerID)
        {
            CustomerViewModel vm = new CustomerViewModel();
            string host = "http://localhost:63927/odata";
            ODataClient client = new ODataClient(host);
            //string query = String.Format("Customers('{0}')?$expand=Orders($expand=Order_Details($expand=Product))", customerID);
            //var a = await client.FindEntryAsync(query);

            vm.Form = await client.For<Customer>().Key(customerID).Expand("Orders,Orders/Order_Details,Orders/Order_Details/Product").FindEntryAsync();

            return vm;
        }
    }
}