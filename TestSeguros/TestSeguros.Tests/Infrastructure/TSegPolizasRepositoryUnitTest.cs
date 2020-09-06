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
    public class TSegPolizasRepositoryUnitTest
    {
        [TestMethod]
        public void createPolicyOkTest()
        {
            Mock<SegurosContext> mock = new Mock<SegurosContext>();
            mock.Setup(x => x.TSeg_Polizas.Add(It.IsAny<TSeg_Polizas>())).Returns(getTSegPoliza());
            TSegPolizasRepository test = new TSegPolizasRepository(mock.Object);
            var response = test.CreateTSegPoliza(getTSegPolizaRequest());
            Assert.IsTrue(response.id > 0);
        }

        [TestMethod]
        public void deletePolicyOkTest()
        {
            Mock<SegurosContext> mock = new Mock<SegurosContext>();
            mock.Setup(x => x.TSeg_Polizas.Remove(It.IsAny<TSeg_Polizas>()));
            TSegPolizasRepository test = new TSegPolizasRepository(mock.Object);
            test.DeleteTSegPoliza(getTSegPolizaRequest());
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
