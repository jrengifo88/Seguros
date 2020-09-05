using System;
using System.Collections.Generic;
using System.Text;

namespace TestSeguros.Application.Response
{
    public class CustomerPolicyResponse
    {
        public long id_poliza { get; set; }
        public long id_cliente { get; set; }
        public string fecha_inicio { get; set; }
        public short meses_cobertura { get; set; }
        public string cobertura { get; set; }
        public string precio { get; set; }
        public string riesgo { get; set; }

        public string nombre_poliza { get; set; }

    }
}
