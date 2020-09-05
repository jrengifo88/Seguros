using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Domain.Abstraction
{
    public interface ICustomerDomainService
    {
        TSeg_Clientes CreateCustomer(TSeg_Clientes customer);
    }
}
