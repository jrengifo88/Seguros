using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.Repositories
{
    public class TSegClientesPolizasRepository : ITSegClientesPolizasRepository
    {
        private readonly SegurosContext _context;

        public TSegClientesPolizasRepository(SegurosContext context)
        {
            _context = context;
        }

        public TSegClientesPolizasRepository()
        {
            _context = new SegurosContext();
        }

       
        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public TSeg_Clientes_Polizas CreateTSegClientesPolizas(TSeg_Clientes_Polizas tSegClientePoliza)
        {
            try
            {
                _context.TSeg_Clientes_Polizas.Add(tSegClientePoliza);
                _context.SaveChanges();
                return tSegClientePoliza;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
