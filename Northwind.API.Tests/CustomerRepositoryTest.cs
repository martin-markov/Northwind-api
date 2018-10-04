using Moq;
using Northwind.API.Models;
using Northwind.API.Repositories;
using Northwind.API.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace Northwind.API.Tests
{
    [TestFixture]
    public class CustomerRepositoryTest
    {
        protected IQueryable<Customer> customersSample;

        [OneTimeSetUp]
        protected void Initialize()
        {
            MapperConfig.MapEntitiesToDTO();
            customersSample = GetCustomersSampleList();
        }

        
        [Test]
        public void Test_GetAll_Should_Return_NonEmptyList()
        {
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            mock.Setup(m => m.GetAll()).Returns(customersSample);

            CustomerService service = new CustomerService(mock.Object);
            var result = service.GetAll();
            Assert.AreEqual(customersSample.Count(), result.Count());
        }

        [Test]
        public void Test_GetById_Should_Return_Entry()
        {
            string customerId = customersSample.FirstOrDefault().CustomerID;
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            mock.Setup(m => m.GetById(customerId)).Returns(customersSample.Where(x => x.CustomerID == customerId));

            CustomerService service = new CustomerService(mock.Object);
            var result = service.GetById(customerId);
            Assert.IsNotNull(result);
            Assert.AreEqual(customerId, result.First().CustomerID);
        }

        [Test]
        public void Test_HasAny_Discontinued_Product()
        {
            string customerId = customersSample.FirstOrDefault().CustomerID;
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            mock.Setup(m => m.GetCustomerOrders(customerId)).Returns(customersSample.FirstOrDefault().Orders.AsQueryable());

            CustomerService service = new CustomerService(mock.Object);
            var result = service.GetCustomerOrders(customerId);
            Assert.IsTrue(result.Any(x => x.HasDiscontinuedProduct));
        }

        private IQueryable<Customer> GetCustomersSampleList()
        {
            List<Customer> temp = new List<Customer>()
            {
                new Customer()
                {
                    ContactName = "John Doe",
                    CustomerID = "ASDF",
                    Orders = new List<Order>(){
                        new Order(){
                            Freight = 34.53m,
                            ShipName = "Sample ship name",
                            Order_Details = new List<Order_Detail>(){
                                new Order_Detail(){
                                    Discount = 0.1f,
                                    Quantity = 5,
                                    UnitPrice = 4.20m,
                                    Product = new Product(){
                                        Discontinued = true,
                                        UnitsInStock = 3,
                                        UnitsOnOrder = 4
                                    }
                                }
                            }
                        }
                    }
                },
                new Customer()
                {
                    ContactName = "Jane Doe",
                    CustomerID = "QWER",
                    Orders = new List<Order>(){
                        new Order(){
                            Freight = 34.53m,
                            ShipName = "Sample ship name",
                            Order_Details = new List<Order_Detail>(){
                                new Order_Detail(){
                                    Discount = 0.1f,
                                    Quantity = 5,
                                    UnitPrice = 4.20m,
                                    Product = new Product(){
                                        Discontinued = false,
                                        UnitsInStock = 10,
                                        UnitsOnOrder = 4
                                    }
                                }
                            }
                        }
                    }
                },
                new Customer()
                {
                    ContactName = "Jane Doe",
                    CustomerID = "ZXCV",
                    Orders = new List<Order>(){
                        new Order(){
                            Freight = 34.53m,
                            ShipName = "Sample ship name",
                            Order_Details = new List<Order_Detail>(){
                                new Order_Detail(){
                                    Discount = 0.1f,
                                    Quantity = 5,
                                    UnitPrice = 4.20m,
                                    Product = new Product(){
                                        Discontinued = false,
                                        UnitsInStock = 40,
                                        UnitsOnOrder = 4
                                    }
                                }
                            }
                        }
                    }
                }
            };
            return temp.AsQueryable();
        }
    }
}
