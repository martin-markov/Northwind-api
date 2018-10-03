using Northwind.DTO;
using System.Collections.Generic;

namespace Northwind.UI.Models
{
    public class CustomerViewModel
    {
        public CustomerDTO CustomerInfo { get; set; }
        public IEnumerable<OrderDTO> CustomerOrders { get; set; }
    }
}