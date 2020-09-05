﻿using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.Data;

namespace TestSeguros.ApplicationServices.Mapper
{
    public static class PolicyMapper
    {
        public static TSeg_Polizas TransformPolicyRequestToTSegPoliza(PolicyRequest policyRequest)
        {
            return new TSeg_Polizas
            {
                nombre = policyRequest.nombre,
                descripcion = policyRequest.descripcion,
                id = policyRequest.id
            };
        }
        public static PolicyResponse TransformTSegPolizaToPolicyResponse(TSeg_Polizas policy)
        {
            return new PolicyResponse
            {
                nombre = policy.nombre,
                descripcion = policy.descripcion,
                id = policy.id
            };
        }

        public static List<PolicyResponse> TransformTSegPolizasToPolicyResponseList(List<TSeg_Polizas> customers)
        {
            List<PolicyResponse> result = new List<PolicyResponse>();

            foreach (TSeg_Polizas i in customers)
            {
                result.Add(TransformTSegPolizaToPolicyResponse(i));
            }
            return result;
        }



    }
}
