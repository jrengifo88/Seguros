using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestSeguros.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicación de prueba para Seguros.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Juan David Rengifo D.";

            return View();
        }

        public ActionResult Opciones()
        {
            return View();
        }
    }
}