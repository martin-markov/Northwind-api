using Northwind.DTO;
using System;
using System.Linq;

namespace Northwind.API.Services
{
    public interface ICustomerService: IDisposable
    {
        IQueryable<CustomerDTO> GetAll();
        IQueryable<CustomerDTO> GetById(string id);
        IQueryable<OrderDTO> GetCustomerOrders(string id);
    }
}
