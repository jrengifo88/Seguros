using System;
using System.Collections.Generic;
using System.Text;

namespace TestSeguros.Application.Response
{
    public class CustomerResponse
    {
        public long id { get; set; }
        public string tipo_identificacion { get; set; }
        public string identificacion { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
    }
}
