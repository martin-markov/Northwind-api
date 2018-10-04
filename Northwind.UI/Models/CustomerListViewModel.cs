using Northwind.DTO;
using System.Collections.Generic;

namespace Northwind.UI.Models
{
    public class CustomerListViewModel
    {
        public CustomerListViewModel()
        {
            this.Customers = new List<CustomerDTO>();
        }
        public IEnumerable<CustomerDTO> Customers { get; set; }
    }
}