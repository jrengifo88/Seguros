using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.DomainServices.Helpers;
using TestSeguros.Repositories;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.DomainServices
{
    public class UserDomainService : IUserDomainService
    {
        ITSegUsuariosRepository UserRepository { get; set; }

        public UserDomainService(ITSegUsuariosRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public UserDomainService()
        {
            UserRepository = new TSegUsuariosRepository();
        }
        public TSeg_Usuarios CreateUser(TSeg_Usuarios user)
        {
            user.contrasena = Encryption.CreateMD5Hash(user.contrasena);
            user.estado = 1;
            return UserRepository.CreateTSegUsuario(user);
        }

        public bool ValidateUser(TSeg_Usuarios user)
        {
            user.contrasena = Encryption.CreateMD5Hash(user.contrasena);
            return UserRepository.ValidateUser(user);
        }
    }
}
