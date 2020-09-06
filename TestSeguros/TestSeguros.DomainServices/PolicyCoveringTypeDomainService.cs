using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.Repositories;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.DomainServices
{
    public class PolicyCoveringTypeDomainService : IPolicyCoveringTypeDomainService
    {
        ITSegPolizaTipoCubrimientoRepository PolicyCoveringRepository { get; set; }

        public PolicyCoveringTypeDomainService(ITSegPolizaTipoCubrimientoRepository repository)
        {
            PolicyCoveringRepository = repository;
        }

        public PolicyCoveringTypeDomainService()
        {
            PolicyCoveringRepository = new TSegPolizaTipoCubrimientoRepository();
        }

        public TSeg_Polizas_Tipo_Cubrimiento CreatePolicyCoveringType(TSeg_Polizas_Tipo_Cubrimiento policyCoveringType)
        {
            return PolicyCoveringRepository.CreateTSegPolizaTipoCubrimiento(policyCoveringType);
        }
    }
}
