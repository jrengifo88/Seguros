using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.Data;

namespace TestSeguros.ApplicationServices.Mapper
{
    public static class PolicyCoveringTypeMapper
    {
        public static TSeg_Polizas_Tipo_Cubrimiento TransformPolicyCoveringTypeRequestToTSegPolizaTipoCubrimiento(PolicyCoveringTypeRequest request)
        {
            return new TSeg_Polizas_Tipo_Cubrimiento
            {
                id_poliza = request.id_poliza,
                id_tipo_cubrimiento = request.id_tipo_cubrimiento
            };
        }
        public static PolicyCoveringTypeResponse TransformTSegPolizaTipoCubrimientoToPolicyCoveringTypResponse(TSeg_Polizas_Tipo_Cubrimiento policyCoveringType)
        {
            return new PolicyCoveringTypeResponse
            {
                id_poliza = policyCoveringType.id_poliza,
                id_tipo_cubrimiento = policyCoveringType.id_tipo_cubrimiento
            };
        }


        
    }
}
