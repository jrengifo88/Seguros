using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSeguros.Application.Request;

namespace TestSeguros.Validations
{
    public static class CustomerPolicyValidation
    {
        public static void validationsAddPolicy(CustomerPolicyRequest customerPolicy)
        {
            if(customerPolicy.id_cliente <= 0){
                throw new Exception("El id de cliente no puede ser menor a 1");
            }
            if (customerPolicy.id_poliza <= 0)
            {
                throw new Exception("El id de póliza no puede ser menor a 1");
            }
            if (customerPolicy.cobertura <= 0 || customerPolicy.cobertura>100)
            {
                throw new Exception("El porcentaje de cobertura debe estar entre 0 y 100");
            }
            if (customerPolicy.riesgo.Equals("Alto") && customerPolicy.cobertura > 50)
            {
                throw new Exception("Para riesgo alto el porcentaje de cobertura debe ser máximo 50");
            }

        }
    }
}