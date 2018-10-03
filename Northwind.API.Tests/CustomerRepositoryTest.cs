using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Northwind.API.Repositories;
using Northwind.API.Services;

namespace Northwind.API.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {

        [TestMethod]
        public void Test_GetAll_Should_Return_NonEmpty()
        {
            IEnumerable<Customer> sampleList = GetCustomersList();
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            mock.Setup(m => m.GetAll()).Returns(sampleList);

            CustomerService service = new CustomerService(mock.Object);
            var result = service.GetAll();

            Assert.AreEqual(sampleList.Count(), result.Count());
        }

        private IEnumerable<Customer> GetCustomersList()
        {
            List<Customer> temp = new List<Customer>()
            {
                new Customer()
                {
                    ContactName = "John Doe",
                    CustomerID = "ASDF",
                },
                new Customer()
                {
                    ContactName = "Jane Doe",
                    CustomerID = "QWER",
                },
                new Customer()
                {
                    ContactName = "Jane Doe",
                    CustomerID = "ZXCV",
                }
            };
            return temp.AsEnumerable();
        }
    }
}
