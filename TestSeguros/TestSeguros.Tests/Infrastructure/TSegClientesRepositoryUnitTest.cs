using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestSeguros.Application.Abstraction;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.DomainServices;
using TestSeguros.Repositories;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.Tests.Controllers
{
    [TestClass]
    public class TSegClientesRepositoryUnitTest
    {
        [TestMethod]
        public void createCustomerOkTest()
        {
            Mock<SegurosContext> mock = new Mock<SegurosContext>();
            mock.Setup(x => x.TSeg_Clientes.Add(It.IsAny<TSeg_Clientes>())).Returns(getTSegCliente());
            TSegClientesRepository test = new TSegClientesRepository(mock.Object);
            var response = test.CreateTSegCliente(getTSegClienteRequest());
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void deleteCustomerOkTest()
        {
            Mock<SegurosContext> mock = new Mock<SegurosContext>();
            mock.Setup(x => x.TSeg_Clientes.Remove(It.IsAny<TSeg_Clientes>()));
            TSegClientesRepository test = new TSegClientesRepository(mock.Object);
            test.DeleteTSegCliente(getTSegClienteRequest());
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
