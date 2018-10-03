using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.API.Repositories
{
    public interface ICustomerRepository : IDisposable 
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(string id);
        IEnumerable<Order> GetCustomerOrders(string id);
    }
}
