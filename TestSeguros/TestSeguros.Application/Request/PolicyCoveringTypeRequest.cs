﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestSeguros.Application.Request
{
    public class PolicyCoveringTypeRequest
    {
        public long id_poliza { get; set; }
        public long id_tipo_cubrimiento { get; set; }
    }
}
