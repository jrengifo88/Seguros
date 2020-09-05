using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;

namespace TestSeguros.Application.Abstraction
{
    public interface IUserApplicationService
    {
        bool ValidateUser(string user, string password);

        long CreateUser(string user, string password);
    }
}
