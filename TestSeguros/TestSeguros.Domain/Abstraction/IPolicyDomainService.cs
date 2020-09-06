using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Domain.Abstraction
{
    public interface IPolicyDomainService
    {
        TSeg_Polizas CreatePolicy(TSeg_Polizas policy);
        List<TSeg_Polizas> ReadPolicies();
        TSeg_Polizas ReadPolicyById(long id);
        long DeletePolicy(TSeg_Polizas policy);

        void UpdatePolicy(TSeg_Polizas policy);
    }
}
