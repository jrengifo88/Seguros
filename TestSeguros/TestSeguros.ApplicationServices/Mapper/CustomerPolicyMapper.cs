using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.Data;

namespace TestSeguros.ApplicationServices.Mapper
{
    public static class CustomerPolicyMapper
    {
        public static TSeg_Clientes_Polizas TransformCustomerPolicyRequestToTSegClientePoliza(CustomerPolicyRequest customerPolicyRequest)
        {
            return new TSeg_Clientes_Polizas
            {
                cobertura = customerPolicyRequest.cobertura,
                fecha_inicio = customerPolicyRequest.fecha_inicio,
                meses_cobertura = customerPolicyRequest.meses_cobertura,
                precio = customerPolicyRequest.precio,
                riesgo = customerPolicyRequest.riesgo,
                id_poliza = customerPolicyRequest.id_poliza,
                id_cliente = customerPolicyRequest.id_cliente
            };
        }
        public static CustomerPolicyResponse TransformTSegClientePolizaToCustomerPolicyResponse(TSeg_Clientes_Polizas customerPolicy)
        {
            return new CustomerPolicyResponse
            {
                cobertura = customerPolicy.cobertura,
                fecha_inicio = customerPolicy.fecha_inicio,
                meses_cobertura = customerPolicy.meses_cobertura,
                precio = customerPolicy.precio,
                riesgo = customerPolicy.riesgo,
                id_poliza = customerPolicy.id_poliza,
                id_cliente = customerPolicy.id_cliente
            };
        }


        
    }
}
