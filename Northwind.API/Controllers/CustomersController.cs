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

namespace Northwind.API.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository _repo;

        public CustomersController()
        {
            _repo = new CustomerRepository();
        }

        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        // GET api/Customers
        public IEnumerable<CustomerDTO> GetCustomers(string includeProps="")
        {
            IEnumerable<Customer> customers = _repo.GetAll(includeProps);
            IEnumerable<CustomerDTO> customersDTO = Mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return customersDTO;

        }

        // GET api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(string id)
        {
            Customer customer = _repo.GetById(id);

            return Ok(customer);
        }

        [Route("api/Customers/{id}/Orders")]
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult GetCustomerOrders(string id)
        {
            Customer customer = _repo.GetCustomerOrders(id);

            return Ok(customer);
        }
    }
}