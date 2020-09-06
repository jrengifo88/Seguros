using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestSeguros.Application.Abstraction;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices;

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

        public PolicyController()
        {
            PolicyApplicationService = new PolicyApplicationService();
        }

        [HttpPost]
        [Route("")]
        public PolicyResponse CreatePolicy([FromBody] PolicyRequest policyRequest)
        {
            return PolicyApplicationService.CreatePolicy(policyRequest);
        }

        [HttpGet]
        [Route("")]
        public List<PolicyResponse> ReadPolicy()
        {
            return PolicyApplicationService.ReadPolicies();
        }

        [HttpDelete]
        [Route("")]
        public long DeletePolicy([FromBody] PolicyRequest policyRequest)
        {
            return PolicyApplicationService.DeletePolicy(policyRequest.id);
        }

        [HttpGet]
        [Route("GetById")]
        public PolicyResponse ReadPolicyById([FromBody] PolicyRequest policyRequest)
        {
            return PolicyApplicationService.ReadPolicyById(policyRequest.id);
        }


    }
}
