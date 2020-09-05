using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.Repositories;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.DomainServices
{
    public class CoveringTypeDomainService : ICoveringTypeDomainService
    {
        ITSegTipoCubrimientoRepository TipoCubrimientoRepository { get; set; }

        public CoveringTypeDomainService(ITSegTipoCubrimientoRepository repository)
        {
            TipoCubrimientoRepository = repository;
        }

        public CoveringTypeDomainService()
        {
            TipoCubrimientoRepository = new TSegTipoCubrimientoRepository();
        }

        public TSeg_Tipo_Cubrimiento CreateCoveringType(TSeg_Tipo_Cubrimiento coveringType)
        {
            return TipoCubrimientoRepository.CreateTSegTipoCubrimiento(coveringType);
        }

        public List<TSeg_Tipo_Cubrimiento> ReadCoveringTypes()
        {
            return TipoCubrimientoRepository.ReadTSegTipoCubrimientos();
        }

        public long DeleteCoveringType(TSeg_Tipo_Cubrimiento coveringType)
        {
            TipoCubrimientoRepository.DeleteTSegTipoCubrimiento(coveringType);
            return coveringType.id;
        }

        public TSeg_Tipo_Cubrimiento ReadTSegTipoCubrimientoById(long id)
        {
            return TipoCubrimientoRepository.ReadTSegTipoCubrimientoById(id);
        }
    }
}
