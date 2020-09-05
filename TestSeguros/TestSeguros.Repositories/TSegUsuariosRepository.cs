using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.Repositories
{
    public class TSegUsuariosRepository : ITSegUsuariosRepository
    {
        private readonly SegurosContext _context;

        public TSegUsuariosRepository(SegurosContext context)
        {
            _context = context;
        }

        public TSegUsuariosRepository()
        {
            _context = new SegurosContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<TSeg_Polizas> ReadTSegPolizas()
        {
            return _context.TSeg_Polizas.ToList();
        }

        public bool ValidateUser(TSeg_Usuarios tSegUsuario)
        {
            try
            {
                TSeg_Usuarios tSegUsuarioResult = _context.TSeg_Usuarios.Where(x => x.usuario == tSegUsuario.usuario && 
                                                                                    x.contrasena == tSegUsuario.contrasena
                                                                                    && x.estado == 1).FirstOrDefault();
                return tSegUsuarioResult == null ? false : true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public TSeg_Usuarios CreateTSegUsuario(TSeg_Usuarios tSegUsuario)
        {
            try
            {
                _context.TSeg_Usuarios.Add(tSegUsuario);
                _context.SaveChanges();
                return tSegUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
