﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OrderCount { get; set; }
    }
}
