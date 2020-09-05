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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        ICustomerApplicationService CustomerApplicationService { get; set; }

        /// <summary>
        ///  Customer Controller Constructor
        /// </summary>
        /// <param name="customerApplicationService">Customer Application Service</param>
        public CustomerController(ICustomerApplicationService customerApplicationService)
        {
            CustomerApplicationService = customerApplicationService;
        }

        public CustomerController()
        {
            CustomerApplicationService = new CustomerApplicationService();
        }

        [HttpPost]
        [Route("")]
        public CustomerResponse CreateCustomer([FromBody] CustomerRequest customerRequest)
        {
            return CustomerApplicationService.CreateCustomer(customerRequest);
        }

    }
}
