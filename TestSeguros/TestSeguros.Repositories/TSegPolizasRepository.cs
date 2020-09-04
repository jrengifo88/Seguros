using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.Repositories
{
    public class TSegPolizasRepository : ITSegPolizasRepository
    {
        private readonly SegurosContext _context;

        public TSegPolizasRepository(SegurosContext context)
        {
            _context = context;
        }

        public TSegPolizasRepository()
        {
            _context = new SegurosContext();
        }
        public TSeg_Polizas CreateTSegPoliza(TSeg_Polizas tSegPoliza)
        {
            try
            {
                _context.TSeg_Polizas.Add(tSegPoliza);
                _context.SaveChanges();
                return tSegPoliza;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTSegPoliza(TSeg_Polizas tSegPoliza)
        {
            _context.TSeg_Polizas.Remove(tSegPoliza);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<TSeg_Polizas> ReadTSegPolizas()
        {
            return _context.TSeg_Polizas.ToList();
        }

        public void UpdateTSegPoliza(TSeg_Polizas tSegPoliza)
        {
            TSeg_Polizas poliza = _context.TSeg_Polizas.Where(x => x.id == tSegPoliza.id).FirstOrDefault();
            poliza.descripcion = tSegPoliza.descripcion;
            poliza.nombre = tSegPoliza.nombre;
            _context.SaveChanges();
        }
    }
}
