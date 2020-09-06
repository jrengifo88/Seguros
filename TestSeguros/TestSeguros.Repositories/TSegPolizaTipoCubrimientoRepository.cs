using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.Repositories
{
    public class TSegPolizaTipoCubrimientoRepository : ITSegPolizaTipoCubrimientoRepository
    {
        private readonly SegurosContext _context;

        public TSegPolizaTipoCubrimientoRepository(SegurosContext context)
        {
            _context = context;
        }

        public TSegPolizaTipoCubrimientoRepository()
        {
            _context = new SegurosContext();
        }

       
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TSeg_Polizas_Tipo_Cubrimiento CreateTSegPolizaTipoCubrimiento(TSeg_Polizas_Tipo_Cubrimiento tSegPolizaTipoCubrimiento)
        {
            try
            {
                _context.TSeg_Polizas_Tipo_Cubrimiento.Add(tSegPolizaTipoCubrimiento);
                _context.SaveChanges();
                return tSegPolizaTipoCubrimiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
