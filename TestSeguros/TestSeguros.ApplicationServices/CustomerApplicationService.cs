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
            try
            {
                TSeg_Clientes customer = CustomerMapper.TransformCustomerRequestToTSegCliente(customerRequest);
                TSeg_Clientes customerOut = CustomerDomainService.CreateCustomer(customer);
                return customerOut != null ? CustomerMapper.TransformTSegClienteToCustomerResponse(customerOut) : null;
            }
            catch
            {
                return new CustomerResponse();
            }
        }

        public List<CustomerResponse> ReadCustomers()
        {
            List<TSeg_Clientes> customers = CustomerDomainService.ReadCustomers();
            return customers.Count > 0 ? CustomerMapper.TransformTSegClientesToCustomerResponseList(customers) : new List<CustomerResponse>();
        }

        public long DeleteCustomer(long customerId)
        {
            try {
                TSeg_Clientes tSegCustomer = CustomerDomainService.ReadCustomerById(customerId);
                return CustomerDomainService.DeleteCustomer(tSegCustomer);
            }
            catch
            {
                return -1;
            }
        }

        public CustomerResponse ReadCustomerById(long id)
        {
            TSeg_Clientes customer = CustomerDomainService.ReadCustomerById(id);
            return customer != null ? CustomerMapper.TransformTSegClienteToCustomerResponse(customer) : null;
        }
    }
}
