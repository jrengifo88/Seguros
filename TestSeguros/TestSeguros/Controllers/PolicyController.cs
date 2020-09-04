using System;
using System.Collections.Generic;
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
    ///  Poliza Controller
    /// </summary>
    [RoutePrefix("api/policies")]
    public class PolicyController : ApiController
    {
        IPolicyApplicationService PolicyApplicationService { get; set; }

        /// <summary>
        ///  Poliza Controller Constructor
        /// </summary>
        /// <param name="policyApplicationService">Policy Application Service</param>
        public PolicyController(IPolicyApplicationService policyApplicationService)
        {
            PolicyApplicationService = policyApplicationService;
        }

        [HttpPost]
        [Route("")]
        public PolicyResponse CreatePolicy([FromBody] PolicyRequest policyRequest)
        {
            return PolicyApplicationService.CreatePolicy(policyRequest);
        }

    }
}
