using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Domain.Abstraction
{
    public interface ICustomerPolicyDomainService
    {
        TSeg_Clientes_Polizas CreateCustomerPolicy(TSeg_Clientes_Polizas customerPolicy);
    }
}
