﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices;

namespace TestSeguros.Controllers
{
    public class PoliciesController : Controller
    {
        PolicyApplicationService PolicyApplicationService;
        public PoliciesController()
        {
            PolicyApplicationService = new PolicyApplicationService();
        }

        public ActionResult Policies()
        {
            List<PolicyResponse> model = PolicyApplicationService.ReadPolicies();
            return View(model);
        }

        public ActionResult Create()
        {
            return View("~/Views/Policies/Create.cshtml");
        }

        [HttpPost]
        public ActionResult Create(PolicyRequest policy)
        {
            PolicyResponse response = PolicyApplicationService.CreatePolicy(policy);

            if (response.id > 0) return RedirectToAction("Policies");
            else
            {
                ViewBag.Error = "La póliza no pudo ser creada.";
                return View("~/Views/Policies/Create.cshtml");
            }
        }

        public ActionResult Delete(long id)
        {
            long response = PolicyApplicationService.DeletePolicy(id);

            if (response > 0) return RedirectToAction("Policies");
            else
            {
                ViewBag.Error = "El cliente no pudo ser eliminado.";
                return View("~/Views/Policies/Policies.cshtml");
            }
        }


    }
}