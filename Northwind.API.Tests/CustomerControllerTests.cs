using Moq;
using Northwind.API.Controllers;
using Northwind.API.Services;
using Northwind.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace Northwind.API.Tests
{
    public class CustomerControllerTests
    {
        [Test]
        public void Test_GetCustomer_Should_Return_Entry()
        {
            IQueryable<CustomerDTO> customers = new List<CustomerDTO>() {
                new CustomerDTO()
                {
                    ContactName = "John Doe",
                    CustomerID = "ASDF",
                    OrderCount = 3
                }
            }.AsQueryable();
            CustomerDTO customer = customers.First();
            Mock<ICustomerService> mock = new Mock<ICustomerService>();
            mock.Setup(m => m.GetById(It.IsAny<string>())).Returns(customers);

            CustomersController controller = new CustomersController(mock.Object);
            IHttpActionResult response = controller.GetCustomer(customer.CustomerID);
            Assert.IsInstanceOf<OkNegotiatedContentResult<CustomerDTO>>(response);
        }
    }
}
