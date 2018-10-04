using Moq;
using Northwind.DTO;
using Northwind.UI.Controllers;
using Northwind.UI.Models;
using Northwind.UI.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Northwind.UI.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {

        [Test]
        public async Task Test_Details_Should_Return404()
        {
            CustomerViewModel model = new CustomerViewModel();
            model.CustomerInfo = null;
            Mock<ICustomerService> mock = new Mock<ICustomerService>();
            mock.Setup(m => m.GetCustomerDetails(It.IsAny<string>())).Returns(Task.FromResult(model));
            var controller = new HomeController(mock.Object);

            ActionResult result = await controller.Details(It.IsAny<string>());

            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public async Task Test_Details_Should_ReturnEntity()
        {
            CustomerViewModel model = GetSampleCustomer();
            Mock<ICustomerService> mock = new Mock<ICustomerService>();
            mock.Setup(m => m.GetCustomerDetails(It.IsAny<string>())).Returns(Task.FromResult(model));
            var controller = new HomeController(mock.Object);

            ActionResult result = await controller.Details(It.IsAny<string>());
            Assert.IsInstanceOf<ViewResult>(result);
            ViewResult viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult.Model);
        }

        private CustomerViewModel GetSampleCustomer()
        {
            CustomerViewModel vm = new CustomerViewModel()
            {
                CustomerInfo = new CustomerDTO()
                {
                    CustomerID = "ASDF",
                    ContactName = "John Doe",
                },
                CustomerOrders = new List<OrderDTO>(){
                    new OrderDTO(){
                        HasInsufficientQuantity = true,
                        ProductCount = 4,
                        HasDiscontinuedProduct = true,
                    }
                }.AsEnumerable()
            };
            return vm;
        }
    }
}
