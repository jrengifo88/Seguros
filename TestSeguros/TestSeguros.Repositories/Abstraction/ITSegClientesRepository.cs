using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Repositories.Abstraction
{
    public interface ITSegClientesRepository : IDisposable
    {
        TSeg_Clientes CreateTSegCliente(TSeg_Clientes tSegPoliza);
        List<TSeg_Clientes> ReadTSegClientes();
        void UpdateTSegCliente(TSeg_Clientes tSegPoliza);
        void DeleteTSegCliente(TSeg_Clientes tSegPoliza);

    }
}
