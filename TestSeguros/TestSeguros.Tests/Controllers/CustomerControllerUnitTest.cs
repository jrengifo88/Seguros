using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestSeguros.Application.Abstraction;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.Controllers;

namespace TestSeguros.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerUnitTest
    {
        [TestMethod]
        public void createCustomerOkTest()
        {
            Mock<ICustomerApplicationService> CustomerApplicationServiceMock = new Mock<ICustomerApplicationService>();
            CustomerController CustomerController = new CustomerController(CustomerApplicationServiceMock.Object);
            CustomerApplicationServiceMock.Setup(x => x.CreateCustomer(It.IsAny<CustomerRequest>())).Returns(getCustomerResponse());
            var response = CustomerController.CreateCustomer(getCustomerRequest());
            Assert.IsTrue(response.id > 0);
        }

        public CustomerResponse getCustomerResponse()
        {
            return new CustomerResponse
            {
                id = 1,
                nombres = "Juan David",
                apellidos = "Rengifo",
                telefono = "1234546",
                direccion = "Carrera 1",
                tipo_identificacion = "CC",
                identificacion = "12335454"
            };
        }

        public CustomerRequest getCustomerRequest()
        {
            return new CustomerRequest
            {
                id = 1,
                nombres = "Juan David",
                apellidos = "Rengifo",
                telefono = "1234546",
                direccion = "Carrera 1",
                tipo_identificacion = "CC",
                identificacion = "12335454"
            };
        }
    }
}
