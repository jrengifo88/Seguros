using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Application.Abstraction;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices.Mapper;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.DomainServices;

namespace TestSeguros.ApplicationServices
{
    /// <summary>
    ///  Policy Application Service 
    /// </summary>
    public class UserApplicationService: IUserApplicationService
    {
        public IUserDomainService UserDomainService { get; set; }

        public UserApplicationService(IUserDomainService userDomainService)
        {
            UserDomainService = userDomainService;
        }
        public UserApplicationService()
        {
            UserDomainService = new UserDomainService();
        }

        public bool ValidateUser(string user, string password)
        {
            TSeg_Usuarios tSegUser = UserMapper.TransformLoginRequestToTSegUsuario(user, password);
            bool isValid = UserDomainService.ValidateUser(tSegUser);
            return isValid;
        }

        public long CreateUser(string user, string password)
        {
            TSeg_Usuarios tSegUser = UserMapper.TransformLoginRequestToTSegUsuario(user, password);
            TSeg_Usuarios userOut = UserDomainService.CreateUser(tSegUser);
            return userOut != null ? userOut.id : -1;
        }
    }
}
