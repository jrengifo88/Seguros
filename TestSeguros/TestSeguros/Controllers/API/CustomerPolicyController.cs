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
    ///  Customer Controller
    /// </summary>
    [RoutePrefix("api/customerpolicy")]
    public class CustomerPolicyController : ApiController
    {
        ICustomerPolicyApplicationService CustomerPolicyApplicationService { get; set; }

        /// <summary>
        ///  Customer Controller Constructor
        /// </summary>
        /// <param name="customerPolicyApplicationService">Customer Application Service</param>
        public CustomerPolicyController(ICustomerPolicyApplicationService customerPolicyApplicationService)
        {
            CustomerPolicyApplicationService = customerPolicyApplicationService;
        }

        public CustomerPolicyController()
        {
            CustomerPolicyApplicationService = new CustomerPolicyApplicationService();
        }

        [HttpPost]
        [Route("")]
        public CustomerPolicyResponse CreateCustomerPolicy([FromBody] CustomerPolicyRequest customerPolicyRequest)
        {
            return CustomerPolicyApplicationService.CreateCustomerPolicy(customerPolicyRequest);
        }

    }
}
