using Northwind.API.Services;
using Northwind.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Northwind.API.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerService service;

        public CustomersController()
        {
            service = new CustomerService();
        }
        //DI
        public CustomersController(ICustomerService service)
        {
            this.service = service;
        }

        // GET api/Customers
        public IQueryable<CustomerDTO> GetCustomers()
        {
            return service.GetAll();
        }

        // GET api/Customers/5
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult GetCustomer(string id)
        {
            IQueryable<CustomerDTO> customer = service.GetById(id);
            return Ok(customer.First());
        }

        // GET api/Customers/5/Orders
        [Route("api/Customers/{id}/Orders")]
        [ResponseType(typeof(IEnumerable<OrderDTO>))]
        public IHttpActionResult GetCustomerOrders(string id)
        {
            IEnumerable<OrderDTO> orders = service.GetCustomerOrders(id);
            return Ok(orders);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}