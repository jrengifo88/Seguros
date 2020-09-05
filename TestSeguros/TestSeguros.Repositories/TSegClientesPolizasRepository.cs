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
        public TSeg_Clientes_Polizas CreateTSegClientePoliza(TSeg_Clientes_Polizas tSegClientePoliza)
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

        public void DeleteTSegClientePoliza(TSeg_Clientes_Polizas tSegClientePoliza)
        {
            _context.TSeg_Clientes_Polizas.Remove(tSegClientePoliza);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<TSeg_Clientes_Polizas> ReadTSegClientesPolizas()
        {
            return _context.TSeg_Clientes_Polizas.ToList();
        }

        public void UpdateTSegClientePoliza(TSeg_Clientes_Polizas tSegClientePoliza)
        {
            TSeg_Clientes_Polizas clientePoliza = _context.TSeg_Clientes_Polizas
                                           .Where(x => x.id_cliente == tSegClientePoliza.id_cliente && x.id_poliza == tSegClientePoliza.id_poliza).FirstOrDefault();
            clientePoliza.cobertura = tSegClientePoliza.cobertura;
            clientePoliza.fecha_inicio = tSegClientePoliza.fecha_inicio;
            clientePoliza.meses_cobertura = tSegClientePoliza.meses_cobertura;
            clientePoliza.riesgo = tSegClientePoliza.riesgo;
            clientePoliza.precio = tSegClientePoliza.precio;
            clientePoliza.riesgo = tSegClientePoliza.riesgo;
            clientePoliza.riesgo = tSegClientePoliza.riesgo;
            _context.SaveChanges();
        }
    }
}
