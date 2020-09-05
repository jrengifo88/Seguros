using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Domain.Abstraction
{
    public interface ICoveringTypeDomainService
    {
        TSeg_Tipo_Cubrimiento CreateCoveringType(TSeg_Tipo_Cubrimiento coveringType);
        List<TSeg_Tipo_Cubrimiento> ReadCoveringTypes();
        TSeg_Tipo_Cubrimiento ReadTSegTipoCubrimientoById(long id);
        long DeleteCoveringType(TSeg_Tipo_Cubrimiento coveringType);
    }
}
