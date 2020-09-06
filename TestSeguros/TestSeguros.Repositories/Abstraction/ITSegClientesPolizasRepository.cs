using TestSeguros.Data;

namespace TestSeguros.Repositories
{
    public interface ITSegClientesPolizasRepository
    {
        TSeg_Clientes_Polizas CreateTSegClientesPolizas(TSeg_Clientes_Polizas tSegPoliza);
    }
}