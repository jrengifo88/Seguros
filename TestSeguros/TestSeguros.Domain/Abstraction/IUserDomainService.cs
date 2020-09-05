using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Domain.Abstraction
{
    public interface IUserDomainService
    {
        TSeg_Usuarios CreateUser(TSeg_Usuarios user);

        bool ValidateUser(TSeg_Usuarios user);
    }
}
