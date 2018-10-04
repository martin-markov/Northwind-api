using Northwind.API.Models;
using System;
using System.Linq;

namespace Northwind.API.Repositories
{
    public interface ICustomerRepository : IDisposable 
    {
        IQueryable<Customer> GetAll();
        IQueryable<Customer> GetById(string id);
        IQueryable<Order> GetCustomerOrders(string id);
    }
}
