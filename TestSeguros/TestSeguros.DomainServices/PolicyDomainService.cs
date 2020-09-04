using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.Repositories;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.DomainServices
{
    public class PolicyDomainService : IPolicyDomainService
    {
        ITSegPolizasRepository PolicyRepository { get; set; }

        public PolicyDomainService(ITSegPolizasRepository policyRepository)
        {
            PolicyRepository = policyRepository;
        }

        public PolicyDomainService()
        {
            PolicyRepository = new TSegPolizasRepository();
        }
        public TSeg_Polizas CreatePolicy(TSeg_Polizas policy)
        {
            return PolicyRepository.CreateTSegPoliza(policy);
        }
    }
}
