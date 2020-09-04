using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestSeguros.Application.Abstraction;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;

namespace TestSeguros.Controllers
{
    /// <summary>
    ///  Policy Controller
    /// </summary>
    [RoutePrefix("api/policies")]
    [Export(typeof(PolicyController))]
    public class PolicyController : ApiController
    {
        IPolicyApplicationService PolicyApplicationService { get; set; }
        public PolicyController(IPolicyApplicationService policyApplicationService)
        {
            PolicyApplicationService = policyApplicationService;
        }

        [HttpPost]
        [Route("")]
        public PolicyResponse GetPolicy([FromBody] PolicyRequest policyRequest)
        {
            return new PolicyResponse();
        }

    }
}
