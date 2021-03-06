﻿using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;

namespace TestSeguros.Application.Abstraction
{
    public interface ICustomerApplicationService
    {
        CustomerResponse CreateCustomer(CustomerRequest customerRequest);
        List<CustomerResponse> ReadCustomers();
        CustomerResponse ReadCustomerById(long id);
        long DeleteCustomer(long customerId);

    }
}
