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
    public class PolicyControllerUnitTest
    {
        [TestMethod]
        public void createPolicyOkTest()
        {
            Mock<IPolicyApplicationService> policyApplicationServiceMock = new Mock<IPolicyApplicationService>();
            PolicyController policyController = new PolicyController(policyApplicationServiceMock.Object);
            policyApplicationServiceMock.Setup(x => x.CreatePolicy(It.IsAny<PolicyRequest>())).Returns(getPolicyResponse());
            var response = policyController.CreatePolicy(getPolicyRequest());
            Assert.IsTrue(response.id > 0);
        }

        public PolicyResponse getPolicyResponse()
        {
            return new PolicyResponse
            {
                id = 1,
                nombre = "PolizaUno",
                descripcion = "Policy 1"
            };
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
