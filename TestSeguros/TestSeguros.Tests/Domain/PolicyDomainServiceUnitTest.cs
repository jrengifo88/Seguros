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
    public class PolicyDomainServiceUnitTest
    {
        [TestMethod]
        public void createPolicyOkTest()
        {
            Mock<ITSegPolizasRepository> mock = new Mock<ITSegPolizasRepository>();
            mock.Setup(x => x.CreateTSegPoliza(It.IsAny<TSeg_Polizas>())).Returns(getTSegPoliza());
            PolicyDomainService test = new PolicyDomainService(mock.Object);
            var response = test.CreatePolicy(getTSegPolizaRequest());
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void deletePolicyOkTest()
        {
            Mock<ITSegPolizasRepository> mock = new Mock<ITSegPolizasRepository>();
            mock.Setup(x => x.DeleteTSegPoliza(It.IsAny<TSeg_Polizas>()));
            PolicyDomainService test = new PolicyDomainService(mock.Object);
            var response = test.DeletePolicy(getTSegPolizaRequest());
            Assert.IsTrue(response > 0);
        }

        [TestMethod]
        public void readPolicyOkTest()
        {
            Mock<ITSegPolizasRepository> mock = new Mock<ITSegPolizasRepository>();
            mock.Setup(x => x.ReadTSegPolizas()).Returns(getTSegPolizaList());
            PolicyDomainService test = new PolicyDomainService(mock.Object);
            var response = test.ReadPolicies();
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void readPolicyByIdOkTest()
        {
            Mock<ITSegPolizasRepository> mock = new Mock<ITSegPolizasRepository>();
            mock.Setup(x => x.ReadTSegPolizaById(It.IsAny<long>())).Returns(getTSegPoliza());
            PolicyDomainService test = new PolicyDomainService(mock.Object);
            var response = test.ReadPolicyById(1);
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void readPolicyByIdWithoutResultTest()
        {
            Mock<ITSegPolizasRepository> mock = new Mock<ITSegPolizasRepository>();
            mock.Setup(x => x.ReadTSegPolizaById(It.IsAny<long>())).Returns(getTSegPolizaNull());
            PolicyDomainService test = new PolicyDomainService(mock.Object);
            var response = test.ReadPolicyById(100);
            Assert.IsTrue(response == null);
        }

        public TSeg_Polizas getTSegPoliza()
        {
            return new TSeg_Polizas
            {
                id = 1,
                nombre = "Poliza 1",
                descripcion = "Prueba Unitaria 1"
            };
        }

        public TSeg_Polizas getTSegPolizaNull()
        {
            return null;
        }

        public List<TSeg_Polizas> getTSegPolizaList()
        {
            List<TSeg_Polizas> list = new List<TSeg_Polizas>();
            TSeg_Polizas p= new TSeg_Polizas
            {
                id = 1,
                nombre = "Poliza 1",
                descripcion = "Prueba Unitaria 1"
            };
            list.Add(p);
            return list;
        }

        public TSeg_Polizas getTSegPolizaRequest()
        {
            return new TSeg_Polizas
            {
                id = 1,
                nombre = "PolizaUno",
                descripcion = "Policy 1"
            };
        }
    }
}
