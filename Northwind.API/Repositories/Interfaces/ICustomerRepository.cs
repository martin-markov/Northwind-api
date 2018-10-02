using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.API.Repositories
{
    public interface ICustomerRepository : IDisposable 
    {
        IEnumerable<Customer> GetAll(string includeProps="");
        Customer GetById(string id);
        Customer GetCustomerOrders(string id);
    }
}
