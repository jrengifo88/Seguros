using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;

namespace TestSeguros.Application.Abstraction
{
    public interface ICoveringTypeApplicationService
    {
        CoveringTypeResponse CreateCoveringType(CoveringTypeRequest coveringType);
        List<CoveringTypeResponse> ReadCoveringTypes();
        CoveringTypeResponse ReadCoveringTypeById(long id);
        long DeleteCoveringType(long coveringType);
    }
}
