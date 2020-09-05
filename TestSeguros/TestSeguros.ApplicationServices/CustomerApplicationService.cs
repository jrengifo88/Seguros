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
    public class CustomerApplicationService:ICustomerApplicationService
    {
        public ICustomerDomainService CustomerDomainService { get; set; }

        public CustomerApplicationService(ICustomerDomainService customerDomainService)
        {
            CustomerDomainService = customerDomainService;
        }
        public CustomerApplicationService()
        {
            CustomerDomainService = new CustomerDomainService();
        }

        public CustomerResponse CreateCustomer(CustomerRequest customerRequest)
        {
            TSeg_Clientes customer = CustomerMapper.TransformCustomerRequestToTSegCliente(customerRequest);
            TSeg_Clientes customerOut = CustomerDomainService.CreateCustomer(customer);
            return customerOut != null ? CustomerMapper.TransformTSegClienteToCustomerResponse(customerOut) : null;
        }
    }
}
