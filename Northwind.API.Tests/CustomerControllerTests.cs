using Moq;
using Northwind.API.Controllers;
using Northwind.API.Repositories;
using Northwind.API.Services;
using Northwind.DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Northwind.API.Tests
{
    public class CustomerControllerTests
    {
        [Test]
        public void Test_GetCustomer_Should_Return_Entry()
        {
            CustomerDTO customer = new CustomerDTO()
            {
                ContactName = "John Doe",
                CustomerID = "ASDF",
                OrderCount = 3
            };
            Mock<ICustomerService> mock = new Mock<ICustomerService>();
            mock.Setup(m => m.GetById(customer.CustomerID)).Returns(customer);

            CustomersController controller = new CustomersController(mock.Object);
            IHttpActionResult response = controller.GetCustomer(customer.CustomerID);
            Assert.IsInstanceOf<OkNegotiatedContentResult<CustomerDTO>>(response);
        }
    }
}
