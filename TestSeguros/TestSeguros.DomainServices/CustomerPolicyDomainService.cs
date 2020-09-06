using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.Repositories;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.DomainServices
{
    public class CustomerPolicyDomainService : ICustomerPolicyDomainService
    {
        ITSegClientesPolizasRepository CustomerPolicyRepository { get; set; }

        public CustomerPolicyDomainService(ITSegClientesPolizasRepository repository)
        {
            CustomerPolicyRepository = repository;
        }

        public CustomerPolicyDomainService()
        {
            CustomerPolicyRepository = new TSegClientesPolizasRepository();
        }

        public TSeg_Clientes_Polizas CreateCustomerPolicy(TSeg_Clientes_Polizas customerPolicy)
        {
           return CustomerPolicyRepository.CreateTSegClientesPolizas(customerPolicy);
        }
    }
}
