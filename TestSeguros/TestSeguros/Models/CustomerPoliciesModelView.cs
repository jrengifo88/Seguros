using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSeguros.Application.Response;

namespace TestSeguros.Models
{
    public class CustomerPoliciesModelView
    {
        public CustomerResponse customer { get; set; }
        public List<CustomerPolicyResponse> policiesDetails { get; set; }
    }
}