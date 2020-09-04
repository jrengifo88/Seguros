using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Domain.Abstraction;

namespace TestSeguros.ApplicationServices
{
    /// <summary>
    ///  Policy Application Service 
    /// </summary>
    public class PolicyApplicationService
    {
        public IPolicyDomainService PolicyDomainService { get; set; }

        public PolicyApplicationService(IPolicyDomainService policyDomainService)
        {
            PolicyDomainService = policyDomainService;
        }
    }
}
