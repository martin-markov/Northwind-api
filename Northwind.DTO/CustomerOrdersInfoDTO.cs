using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DTO
{
    public class CustomerOrdersInfoDTO : CustomerDTO
    {
        public CustomerOrdersInfoDTO()
        {
            this.Orders = new List<OrderDTO>();
        }
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
