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
    ///  User Controller
    /// </summary>
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        IUserApplicationService UserApplicationService { get; set; }

        /// <summary>
        ///  User Controller Constructor
        /// </summary>
        /// <param name="userApplicationService">User Application Service</param>
        public UserController(IUserApplicationService userApplicationService)
        {
            UserApplicationService = userApplicationService;
        }

        public UserController()
        {
            UserApplicationService = new UserApplicationService();
        }

        [HttpPost]
        [Route("")]
        public long CreateUser([FromBody] string user, string password)
        {
            return UserApplicationService.CreateUser(user, password);
        }

        [HttpPost]
        [Route("")]
        public bool ValidateUser([FromBody] string user, string password)
        {
            return UserApplicationService.ValidateUser(user, password);
        }



    }
}
