using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSeguros.ApplicationServices;

namespace TestSeguros.Controllers
{
    public class LoginController : Controller
    {

        UserApplicationService UserApplicationService;
        [HttpPost]
        public ActionResult Index(string u, string p)
        {
            UserApplicationService = new UserApplicationService();
            bool isValid = UserApplicationService.ValidateUser(u, p);

            if (isValid) return View("~/Views/Home/Opciones.cshtml");
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrecto.";
                return View("~/Views/Home/Index.cshtml");
            }

        }

      
        public ActionResult Register()
        {
            return View("~/Views/Home/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(string u, string p)
        {
            UserApplicationService = new UserApplicationService();
            long userId = UserApplicationService.CreateUser(u, p);

            if(userId>0) return View("~/Views/Home/Opciones.cshtml");
            else
            {
                ViewBag.Error = "Usuario no pudo ser creado.";
                return View("~/Views/Home/Register.cshtml");
            }
            
        }



    }
}