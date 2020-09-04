using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Abstraction;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices.Mapper;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.DomainServices;

namespace TestSeguros.ApplicationServices
{
    /// <summary>
    ///  Policy Application Service 
    /// </summary>
    public class PolicyApplicationService:IPolicyApplicationService
    {
        public IPolicyDomainService PolicyDomainService { get; set; }

        public PolicyApplicationService(IPolicyDomainService policyDomainService)
        {
            PolicyDomainService = policyDomainService;
        }
        public PolicyApplicationService()
        {
            PolicyDomainService = new PolicyDomainService();
        }

        public PolicyResponse CreatePolicy(PolicyRequest policyRequest)
        {
            TSeg_Polizas policy = PolicyMapper.TransformPolicyRequestToTSegPoliza(policyRequest);
            TSeg_Polizas policyOut = PolicyDomainService.CreatePolicy(policy);
            return policyOut != null ? PolicyMapper.TransformTSegPolizaToPolicyResponse(policyOut) : null;
        }
    }
}
