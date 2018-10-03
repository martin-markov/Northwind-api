using AutoMapper;
using Northwind.API.Repositories;
using Northwind.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.API.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repo;

        public CustomerService()
        {
            _repo = new CustomerRepository();
        }

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            IEnumerable<Customer> customers = _repo.GetAll();
            IEnumerable<CustomerDTO> customersDTO = Mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return customersDTO;
        }

        public CustomerDTO GetById(string id)
        {
            Customer customer = _repo.GetById(id);
            CustomerDTO customersDTO = Mapper.Map<CustomerDTO>(customer);

            return customersDTO;
        }

        public IEnumerable<OrderDTO> GetCustomerOrders(string id)
        {
            IEnumerable<Order> orders = _repo.GetCustomerOrders(id);
            IEnumerable<OrderDTO> ordersDTO = Mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ordersDTO;
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _repo.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}