using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Response;

namespace TestSeguros.Application.Request
{
    public class PolicyRequest
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public List<CoveringTypeResponse> TSeg_Tipo_Cubrimiento { get; set; }
    }
}
