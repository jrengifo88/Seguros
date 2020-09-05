using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Domain.Abstraction
{
    public interface ICustomerDomainService
    {
        TSeg_Clientes CreateCustomer(TSeg_Clientes customer);
        List<TSeg_Clientes> ReadCustomers();
        TSeg_Clientes ReadCustomerById(long id);
        long DeleteCustomer(TSeg_Clientes customer);
    }
}
