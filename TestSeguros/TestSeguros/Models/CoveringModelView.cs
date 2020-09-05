using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSeguros.Application.Response;

namespace TestSeguros.Models
{
    public class CoveringModelView
    {
        public PolicyResponse policy { get; set; }
        public List<CoveringTypeResponse> covering { get; set; }
    }
}