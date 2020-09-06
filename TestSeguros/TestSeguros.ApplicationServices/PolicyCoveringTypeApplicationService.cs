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
    public class PolicyCoveringTypeApplicationService : IPolicyCoveringTypeApplicationService
    {
        public IPolicyCoveringTypeDomainService PolicyCoveringTypeDomainService { get; set; }

        public PolicyCoveringTypeApplicationService(IPolicyCoveringTypeDomainService customerPolicyDomainService)
        {
            PolicyCoveringTypeDomainService = customerPolicyDomainService;
        }
        public PolicyCoveringTypeApplicationService()
        {
            PolicyCoveringTypeDomainService = new PolicyCoveringTypeDomainService();
        }

        public PolicyCoveringTypeResponse CreatePolicyCoveringType(PolicyCoveringTypeRequest policyCoveringTypeRequest)
        {
            TSeg_Polizas_Tipo_Cubrimiento policyCovering = PolicyCoveringTypeMapper.TransformPolicyCoveringTypeRequestToTSegPolizaTipoCubrimiento(policyCoveringTypeRequest);
            TSeg_Polizas_Tipo_Cubrimiento policyCoveringOut = PolicyCoveringTypeDomainService.CreatePolicyCoveringType(policyCovering);
            return policyCoveringOut != null ? PolicyCoveringTypeMapper.TransformTSegPolizaTipoCubrimientoToPolicyCoveringTypResponse(policyCoveringOut) : null;

        }
    }
}
