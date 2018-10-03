using Northwind.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.API.Services
{
    public interface ICustomerService: IDisposable
    {
        IEnumerable<CustomerDTO> GetAll();
        CustomerDTO GetById(string id);
        IEnumerable<OrderDTO> GetCustomerOrders(string id);
    }
}
