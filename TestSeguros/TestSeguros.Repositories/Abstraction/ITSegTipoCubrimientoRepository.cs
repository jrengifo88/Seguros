using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Repositories.Abstraction
{
    public interface ITSegTipoCubrimientoRepository : IDisposable
    {
        TSeg_Tipo_Cubrimiento CreateTSegTipoCubrimiento(TSeg_Tipo_Cubrimiento TSegTipoCubrimientoPoliza);
        List<TSeg_Tipo_Cubrimiento> ReadTSegTipoCubrimientos();
        TSeg_Tipo_Cubrimiento ReadTSegTipoCubrimientoById(long id);
        void UpdateTSegTipoCubrimiento(TSeg_Tipo_Cubrimiento tSegPoliza);
        void DeleteTSegTipoCubrimiento(TSeg_Tipo_Cubrimiento tSegPoliza);

    }
}
