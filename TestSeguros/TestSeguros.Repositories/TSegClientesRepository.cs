using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.Repositories
{
    public class TSegClientesRepository : ITSegClientesRepository
    {
        private readonly SegurosContext _context;

        public TSegClientesRepository(SegurosContext context)
        {
            _context = context;
        }

        public TSegClientesRepository()
        {
            _context = new SegurosContext();
        }
        public TSeg_Clientes CreateTSegCliente(TSeg_Clientes tSegCliente)
        {
            try
            {
                _context.TSeg_Clientes.Add(tSegCliente);
                _context.SaveChanges();
                return tSegCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTSegCliente(TSeg_Clientes tSegCliente)
        {
            _context.TSeg_Clientes.Remove(tSegCliente);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<TSeg_Clientes> ReadTSegClientes()
        {
            return _context.TSeg_Clientes.ToList();
        }

        public void UpdateTSegCliente(TSeg_Clientes tSegCliente)
        {
            TSeg_Clientes clientes = _context.TSeg_Clientes.Where(x => x.id == tSegCliente.id).FirstOrDefault();
            clientes.nombres = tSegCliente.nombres;
            clientes.apellidos = tSegCliente.apellidos;
            clientes.direccion = tSegCliente.direccion;
            clientes.telefono = tSegCliente.telefono;
            _context.SaveChanges();
        }
    }
}
