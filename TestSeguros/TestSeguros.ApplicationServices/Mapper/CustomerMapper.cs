using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.Data;

namespace TestSeguros.ApplicationServices.Mapper
{
    public static class CustomerMapper
    {
        public static TSeg_Clientes TransformCustomerRequestToTSegCliente(CustomerRequest customerRequest)
        {
            return new TSeg_Clientes
            {
                nombres = customerRequest.nombres,
                apellidos = customerRequest.apellidos,
                telefono = customerRequest.telefono,
                direccion = customerRequest.direccion,
                tipo_identificacion = customerRequest.tipo_identificacion,
                identificacion = customerRequest.identificacion,
                id = customerRequest.id
            };
        }
        public static CustomerResponse TransformTSegClienteToCustomerResponse(TSeg_Clientes customer)
        {
            return new CustomerResponse
            {
                nombres = customer.nombres,
                apellidos = customer.apellidos,
                telefono = customer.telefono,
                direccion = customer.direccion,
                tipo_identificacion = customer.tipo_identificacion,
                identificacion = customer.identificacion,
                id = customer.id
            };
        }

        public static List<CustomerResponse> TransformTSegClientesToCustomerResponseList(List<TSeg_Clientes> customers)
        {
            List<CustomerResponse> result = new List<CustomerResponse>();

            foreach (TSeg_Clientes i in customers)
            {
                result.Add(TransformTSegClienteToCustomerResponse(i));
            }
            return result;
        }



    }
}
