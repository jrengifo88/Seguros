using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Abstraction;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices.Mapper;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.DomainServices;

namespace TestSeguros.ApplicationServices
{
    /// <summary>
    ///  Policy Application Service 
    /// </summary>
    public class CoveringTypeApplicationService: ICoveringTypeApplicationService
    {
        public ICoveringTypeDomainService CoveringTypeDomain { get; set; }

        public CoveringTypeApplicationService(ICoveringTypeDomainService coveringTypeDomainService)
        {
            CoveringTypeDomain = coveringTypeDomainService;
        }
        public CoveringTypeApplicationService()
        {
            CoveringTypeDomain = new CoveringTypeDomainService();
        }

        public CoveringTypeResponse CreateCoveringType(CoveringTypeRequest coveringTypeRequest)
        {
            TSeg_Tipo_Cubrimiento coveringType = CoveringTypeMapper.TransformCoveringRequestToTSegTipoCubrimiento(coveringTypeRequest);
            TSeg_Tipo_Cubrimiento coveringTypeOut = CoveringTypeDomain.CreateCoveringType(coveringType);
            return coveringTypeOut != null ? CoveringTypeMapper.TransformTSegTipoCubrimientoToCoveringTypeResponse(coveringTypeOut) : null;
        }

        public List<CoveringTypeResponse> ReadCoveringTypes()
        {
            throw new NotImplementedException();
        }

        public long DeleteCoveringType(long coveringTypeId)
        {
            try
            {
                TSeg_Tipo_Cubrimiento coveringType = CoveringTypeDomain.ReadTSegTipoCubrimientoById(coveringTypeId);
                return CoveringTypeDomain.DeleteCoveringType(coveringType);
            }
            catch
            {
                return -1;
            }
        }

        public CoveringTypeResponse ReadCoveringTypeById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
