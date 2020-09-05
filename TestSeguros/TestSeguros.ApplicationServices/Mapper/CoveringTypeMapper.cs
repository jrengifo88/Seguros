using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.Data;

namespace TestSeguros.ApplicationServices.Mapper
{
    public static class CoveringTypeMapper
    {
        public static TSeg_Tipo_Cubrimiento TransformCoveringRequestToTSegTipoCubrimiento(CoveringTypeRequest coveringTypeRequest)
        {
            return new TSeg_Tipo_Cubrimiento
            {
                nombre = coveringTypeRequest.nombre,
                id = coveringTypeRequest.id
            };
        }
        public static CoveringTypeResponse TransformTSegTipoCubrimientoToCoveringTypeResponse(TSeg_Tipo_Cubrimiento coveringType)
        {
            return new CoveringTypeResponse
            {
                nombre = coveringType.nombre,
                id = coveringType.id
            };
        }

        public static List<CoveringTypeResponse> TransformTSegPolizasToPolicyResponseList(List<TSeg_Tipo_Cubrimiento> coveringTypes)
        {
            List<CoveringTypeResponse> result = new List<CoveringTypeResponse>();

            foreach (TSeg_Tipo_Cubrimiento i in coveringTypes)
            {
                result.Add(TransformTSegTipoCubrimientoToCoveringTypeResponse(i));
            }
            return result;
        }



    }
}
