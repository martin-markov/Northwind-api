using AutoMapper.QueryableExtensions;
using Northwind.API.Repositories;
using Northwind.DTO;
using System;
using System.Linq;

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

        public IQueryable<CustomerDTO> GetAll()
        {
            IQueryable<CustomerDTO> customersDTO = _repo.GetAll().ProjectTo<CustomerDTO>("Order");
            return customersDTO;
        }

        public IQueryable<CustomerDTO> GetById(string id)
        {
            IQueryable<CustomerDTO> customerDTO = _repo.GetById(id).ProjectTo<CustomerDTO>();
            return customerDTO;
        }

        public IQueryable<OrderDTO> GetCustomerOrders(string id)
        {
            IQueryable<OrderDTO> ordersDTO = _repo.GetCustomerOrders(id).ProjectTo<OrderDTO>();
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