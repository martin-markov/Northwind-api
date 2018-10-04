using System;

namespace Northwind.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public int ProductCount { get; set; }
        public float TotalPrice { get; set; }
        public bool HasDiscontinuedProduct { get; set; }
        public bool HasInsufficientQuantity { get; set; }

    }
}
