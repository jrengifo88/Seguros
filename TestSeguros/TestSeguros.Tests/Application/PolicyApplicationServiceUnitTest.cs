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
    public class PolicyApplicationServiceUnitTest
    {
        [TestMethod]
        public void createPolicyOkTest()
        {
            Mock<IPolicyDomainService> mock = new Mock<IPolicyDomainService>();
            mock.Setup(x => x.CreatePolicy(It.IsAny<TSeg_Polizas>())).Returns(getTSegPoliza());
            PolicyApplicationService test = new PolicyApplicationService(mock.Object);
            var response = test.CreatePolicy(getPolicyRequest());
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void deletePolicyOkTest()
        {
            Mock<IPolicyDomainService> mock = new Mock<IPolicyDomainService>();
            mock.Setup(x => x.DeletePolicy(It.IsAny<TSeg_Polizas>())).Returns(1);
            PolicyApplicationService test = new PolicyApplicationService(mock.Object);
            var response = test.DeletePolicy(1);
            Assert.IsTrue(response > 0);
        }

        [TestMethod]
        public void readPolicyOkTest()
        {
            Mock<IPolicyDomainService> mock = new Mock<IPolicyDomainService>();
            mock.Setup(x => x.ReadPolicies()).Returns(getTSegPolizaList());
            PolicyApplicationService test = new PolicyApplicationService(mock.Object);
            var response = test.ReadPolicies();
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void readPolicyByIdOkTest()
        {
            Mock<IPolicyDomainService> mock = new Mock<IPolicyDomainService>();
            mock.Setup(x => x.ReadPolicyById(It.IsAny<long>())).Returns(getTSegPoliza());
            PolicyApplicationService test = new PolicyApplicationService(mock.Object);
            var response = test.ReadPolicyById(1);
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void readPolicyByIdWithoutResultTest()
        {
            Mock<IPolicyDomainService> mock = new Mock<IPolicyDomainService>();
            mock.Setup(x => x.ReadPolicyById(It.IsAny<long>())).Returns(getTSegPolizaNull());
            PolicyApplicationService test = new PolicyApplicationService(mock.Object);
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

        public PolicyRequest getPolicyRequest()
        {
            return new PolicyRequest
            {
                nombre = "PolizaUno",
                descripcion = "Policy 1"
            };
        }
    }
}
