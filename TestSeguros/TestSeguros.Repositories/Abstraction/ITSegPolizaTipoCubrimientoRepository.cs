using TestSeguros.Data;

namespace TestSeguros.Repositories
{
    public interface ITSegPolizaTipoCubrimientoRepository
    {
        TSeg_Polizas_Tipo_Cubrimiento CreateTSegPolizaTipoCubrimiento(TSeg_Polizas_Tipo_Cubrimiento tSegPolizaTipoCubrimiento);
    }
}