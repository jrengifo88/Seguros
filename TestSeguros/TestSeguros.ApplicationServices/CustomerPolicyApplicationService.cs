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
    public class CustomerPolicyApplicationService:ICustomerPolicyApplicationService
    {
        public ICustomerPolicyDomainService CustomerPolicyDomainService { get; set; }

        public CustomerPolicyApplicationService(ICustomerPolicyDomainService customerPolicyDomainService)
        {
            CustomerPolicyDomainService = customerPolicyDomainService;
        }
        public CustomerPolicyApplicationService()
        {
            CustomerPolicyDomainService = new CustomerPolicyDomainService();
        }

        public CustomerPolicyResponse CreateCustomerPolicy(CustomerPolicyRequest customerPolicyRequest)
        {
            TSeg_Clientes_Polizas customerPolicy = CustomerPolicyMapper.TransformCustomerPolicyRequestToTSegClientePoliza(customerPolicyRequest);
            TSeg_Clientes_Polizas customerPolicyOut = CustomerPolicyDomainService.CreateCustomerPolicy(customerPolicy);
            return customerPolicyOut != null ? CustomerPolicyMapper.TransformTSegClientePolizaToCustomerPolicyResponse(customerPolicyOut) : null;
        }
    }
}
