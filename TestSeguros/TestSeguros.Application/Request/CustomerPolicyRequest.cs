using System;
using System.Collections.Generic;
using System.Text;

namespace TestSeguros.Application.Request
{
    public class CustomerPolicyRequest
    {
        public long id_poliza { get; set; }
        public long id_cliente { get; set; }
        public DateTime fecha_inicio { get; set; }
        public short? meses_cobertura { get; set; }
        public decimal? cobertura { get; set; }
        public decimal? precio { get; set; }
        public string riesgo { get; set; }

    }
}
