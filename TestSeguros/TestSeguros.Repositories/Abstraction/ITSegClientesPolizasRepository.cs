using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Repositories.Abstraction
{
    public interface ITSegClientesPolizasRepository : IDisposable
    {
        TSeg_Clientes_Polizas CreateTSegClientePoliza(TSeg_Clientes_Polizas tSegClientePoliza);
        List<TSeg_Clientes_Polizas> ReadTSegClientesPolizas();
        void UpdateTSegClientePoliza(TSeg_Clientes_Polizas tSegPoliza);
        void DeleteTSegClientePoliza(TSeg_Clientes_Polizas tSegPoliza);

    }
}
