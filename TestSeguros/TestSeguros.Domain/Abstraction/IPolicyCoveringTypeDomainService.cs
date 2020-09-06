using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;

namespace TestSeguros.Domain.Abstraction
{
    public interface IPolicyCoveringTypeDomainService
    {
        TSeg_Polizas_Tipo_Cubrimiento CreatePolicyCoveringType(TSeg_Polizas_Tipo_Cubrimiento policyCoveringType);
    }
}
