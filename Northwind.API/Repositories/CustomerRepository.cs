using Northwind.API.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Northwind.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private NorthwindContext db = null;

        public CustomerRepository()
        {
            this.db = new NorthwindContext();
        }

        //DI
        public CustomerRepository(NorthwindContext db)
        {
            this.db = db;
        }

        public IQueryable<Customer> GetAll()
        {
            return db.Customers;
        }

        public IQueryable<Customer> GetById(string id)
        {
            return db.Customers.Where(c => c.CustomerID.Equals(id, StringComparison.InvariantCultureIgnoreCase));
        }

        public IQueryable<Order> GetCustomerOrders(string id)
        {
            return db.Orders.Include(o=>o.Order_Details.Select(x=>x.Product)).Where(m => m.CustomerID.Equals(id, StringComparison.InvariantCultureIgnoreCase));
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}