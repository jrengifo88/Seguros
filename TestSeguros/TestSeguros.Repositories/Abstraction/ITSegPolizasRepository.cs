using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Repositories.Abstraction
{
    public interface ITSegPolizasRepository : IDisposable
    {
        TSeg_Polizas CreateTSegPoliza(TSeg_Polizas tSegPoliza);
        List<TSeg_Polizas> ReadTSegPolizas();
        TSeg_Polizas ReadTSegPolizaById(long id);
        void UpdateTSegPoliza(TSeg_Polizas tSegPoliza);
        void DeleteTSegPoliza(TSeg_Polizas tSegPoliza);
    }
}
