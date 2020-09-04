using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Domain.Abstraction
{
    public interface IPolicyDomainService
    {
        TSeg_Polizas CreatePolicy(TSeg_Polizas policy);
    }
}
