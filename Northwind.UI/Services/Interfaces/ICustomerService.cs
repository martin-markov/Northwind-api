using Northwind.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.UI.Services
{
    public interface ICustomerService
    {
        Task<CustomerListViewModel> GetCustomers(string customerName);
        Task<CustomerViewModel> GetCustomerDetails(string customerID);
    }
}
