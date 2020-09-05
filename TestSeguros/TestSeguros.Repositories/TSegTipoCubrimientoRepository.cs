using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.Repositories
{
    public class TSegTipoCubrimientoRepository : ITSegTipoCubrimientoRepository
    {
        private readonly SegurosContext _context;

        public TSegTipoCubrimientoRepository(SegurosContext context)
        {
            _context = context;
        }

        public TSegTipoCubrimientoRepository()
        {
            _context = new SegurosContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
         
        public TSeg_Tipo_Cubrimiento CreateTSegTipoCubrimiento(TSeg_Tipo_Cubrimiento TSegTipoCubrimientoPoliza)
        {
            try
            {
                _context.TSeg_Tipo_Cubrimiento.Add(TSegTipoCubrimientoPoliza);
                _context.SaveChanges();
                return TSegTipoCubrimientoPoliza;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TSeg_Tipo_Cubrimiento> ReadTSegTipoCubrimientos()
        {
            return _context.TSeg_Tipo_Cubrimiento.ToList();
        }

        public void UpdateTSegTipoCubrimiento(TSeg_Tipo_Cubrimiento tSegTipoCubrimiento)
        {
            TSeg_Tipo_Cubrimiento tipoCubrimiento = _context.TSeg_Tipo_Cubrimiento.Where(x => x.id == tSegTipoCubrimiento.id).FirstOrDefault();
            tipoCubrimiento.nombre = tSegTipoCubrimiento.nombre;
            _context.SaveChanges();
        }

        public void DeleteTSegTipoCubrimiento(TSeg_Tipo_Cubrimiento tSegTipoCubrimiento)
        {
            _context.TSeg_Tipo_Cubrimiento.Remove(tSegTipoCubrimiento);
            _context.SaveChanges();
        }

        public TSeg_Tipo_Cubrimiento ReadTSegTipoCubrimientoById(long id)
        {
            TSeg_Tipo_Cubrimiento tipoCubrimiento = _context.TSeg_Tipo_Cubrimiento.Where(x => x.id == id).FirstOrDefault();
            return tipoCubrimiento;
        }
    }
}
