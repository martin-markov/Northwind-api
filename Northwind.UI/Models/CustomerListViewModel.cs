using Northwind.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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