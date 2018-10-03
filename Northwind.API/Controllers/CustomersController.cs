using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Northwind.API;
using Northwind.API.Repositories;
using Northwind.DTO;
using AutoMapper;
using Northwind.API.Services;

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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return service.GetAll();
        }

        // GET api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(string id)
        {
            CustomerDTO customer = service.GetById(id);
            return Ok(customer);
        }

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