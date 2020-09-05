using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Repositories.Abstraction
{
    public interface ITSegUsuariosRepository : IDisposable
    {
        bool ValidateUser(TSeg_Usuarios tSegUsuario);

        TSeg_Usuarios CreateTSegUsuario(TSeg_Usuarios tSegUsuario);

    }
}
