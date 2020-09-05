using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.Data;

namespace TestSeguros.ApplicationServices.Mapper
{
    public static class UserMapper
    {
        public static TSeg_Usuarios TransformLoginRequestToTSegUsuario(string user, string password)
        {
            return new TSeg_Usuarios
            {
                usuario = user,
                contrasena = password
            };
        }
    }
}
