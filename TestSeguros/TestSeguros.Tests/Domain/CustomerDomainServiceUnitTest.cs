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
using TestSeguros.DomainServices;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.Tests.Controllers
{
    [TestClass]
    public class CustomerDomainServiceUnitTest
    {
        [TestMethod]
        public void createCustomerOkTest()
        {
            Mock<ITSegClientesRepository> mock = new Mock<ITSegClientesRepository>();
            mock.Setup(x => x.CreateTSegCliente(It.IsAny<TSeg_Clientes>())).Returns(getTSegCliente());
            CustomerDomainService test = new CustomerDomainService(mock.Object);
            var response = test.CreateCustomer(getTSegClienteRequest());
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void deleteCustomerOkTest()
        {
            Mock<ITSegClientesRepository> mock = new Mock<ITSegClientesRepository>();
            mock.Setup(x => x.DeleteTSegCliente(It.IsAny<TSeg_Clientes>()));
            CustomerDomainService test = new CustomerDomainService(mock.Object);
            var response = test.DeleteCustomer(getTSegClienteRequest());
            Assert.IsTrue(response > 0);
        }

        [TestMethod]
        public void readCustomerOkTest()
        {
            Mock<ITSegClientesRepository> mock = new Mock<ITSegClientesRepository>();
            mock.Setup(x => x.ReadTSegClientes()).Returns(getTSegClienteList());
            CustomerDomainService test = new CustomerDomainService(mock.Object);
            var response = test.ReadCustomers();
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void readCustomerByIdOkTest()
        {
            Mock<ITSegClientesRepository> mock = new Mock<ITSegClientesRepository>();
            mock.Setup(x => x.ReadTSegClienteById(It.IsAny<long>())).Returns(getTSegCliente());
            CustomerDomainService test = new CustomerDomainService(mock.Object);
            var response = test.ReadCustomerById(1);
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void readCustomerByIdWithoutResultTest()
        {
            Mock<ITSegClientesRepository> mock = new Mock<ITSegClientesRepository>();
            mock.Setup(x => x.ReadTSegClienteById(It.IsAny<long>())).Returns(getTSegClienteNull());
            CustomerDomainService test = new CustomerDomainService(mock.Object);
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

        public TSeg_Clientes getTSegClienteNull()
        {
            return null;
        }

        public List<TSeg_Clientes> getTSegClienteList()
        {
            List<TSeg_Clientes> list = new List<TSeg_Clientes>();
            TSeg_Clientes p= new TSeg_Clientes
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

        public TSeg_Clientes getTSegClienteRequest()
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
    }
}
