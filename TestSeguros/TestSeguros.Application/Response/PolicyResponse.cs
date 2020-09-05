using System;
using System.Collections.Generic;
using System.Text;

namespace TestSeguros.Application.Response
{
    public class PolicyResponse
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<CoveringTypeResponse> TSeg_Tipo_Cubrimiento { get; set; }
    }
}
