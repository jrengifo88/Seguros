using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestSeguros.Application.Abstraction;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;

namespace TestSeguros.Tests.Controllers
{
    [TestClass]
    public class CustomerApplicationServiceUnitTest
    {
        [TestMethod]
        public void createCustomerOkTest()
        {
            Mock<ICustomerDomainService> mock = new Mock<ICustomerDomainService>();
            mock.Setup(x => x.CreateCustomer(It.IsAny<TSeg_Clientes>())).Returns(getTSegCliente());
            CustomerApplicationService test = new CustomerApplicationService(mock.Object);
            var response = test.CreateCustomer(getCustomerRequest());
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void deleteCustomerOkTest()
        {
            Mock<ICustomerDomainService> mock = new Mock<ICustomerDomainService>();
            mock.Setup(x => x.DeleteCustomer(It.IsAny<TSeg_Clientes>())).Returns(1);
            CustomerApplicationService test = new CustomerApplicationService(mock.Object);
            var response = test.DeleteCustomer(1);
            Assert.IsTrue(response > 0);
        }

        [TestMethod]
        public void readCustomerOkTest()
        {
            Mock<ICustomerDomainService> mock = new Mock<ICustomerDomainService>();
            mock.Setup(x => x.ReadCustomers()).Returns(getTSegClienteList());
            CustomerApplicationService test = new CustomerApplicationService(mock.Object);
            var response = test.ReadCustomers();
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void readCustomerByIdOkTest()
        {
            Mock<ICustomerDomainService> mock = new Mock<ICustomerDomainService>();
            mock.Setup(x => x.ReadCustomerById(It.IsAny<long>())).Returns(getTSegCliente());
            CustomerApplicationService test = new CustomerApplicationService(mock.Object);
            var response = test.ReadCustomerById(1);
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void readCustomerByIdWithoutResultTest()
        {
            Mock<ICustomerDomainService> mock = new Mock<ICustomerDomainService>();
            mock.Setup(x => x.ReadCustomerById(It.IsAny<long>())).Returns(getTSegPolizaNull());
            CustomerApplicationService test = new CustomerApplicationService(mock.Object);
            var response = test.ReadCustomerById(100);
            Assert.IsTrue(response == null);
        }

        public TSeg_Clientes getTSegCliente()
        {
            return new TSeg_Clientes
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

        public TSeg_Clientes getTSegPolizaNull()
        {
            return null;
        }

        public List<TSeg_Clientes> getTSegClienteList()
        {
            List<TSeg_Clientes> list = new List<TSeg_Clientes>();
            TSeg_Clientes p = new TSeg_Clientes
            {
                id = 1,
                nombres = "Juan David",
                apellidos = "Rengifo",
                telefono = "1234546",
                direccion = "Carrera 1",
                tipo_identificacion = "CC",
                identificacion = "12335454"
            };
            list.Add(p);
            return list;
        }

        public CustomerRequest getCustomerRequest()
        {
            return new CustomerRequest
            {
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
