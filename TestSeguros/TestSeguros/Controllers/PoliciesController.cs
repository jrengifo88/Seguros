using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices;
using TestSeguros.Models;

namespace TestSeguros.Controllers
{
    public class PoliciesController : Controller
    {
        PolicyApplicationService PolicyApplicationService;
        CoveringTypeApplicationService CoveringTypeApplicationService;
        PolicyCoveringTypeApplicationService PolicyCoveringTypeApplicationService;

        public PoliciesController()
        {
            PolicyApplicationService = new PolicyApplicationService();
            CoveringTypeApplicationService = new CoveringTypeApplicationService();
            PolicyCoveringTypeApplicationService = new PolicyCoveringTypeApplicationService();
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

        public ActionResult Details(long id)
        {
            PolicyResponse policy = PolicyApplicationService.ReadPolicyById(id);
            CoveringModelView model = new CoveringModelView();
            model.policy = policy;
            model.covering = policy.TSeg_Tipo_Cubrimiento;

            return View("~/Views/Policies/CoveringDetails.cshtml", model);

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

        public ActionResult AddCovering(long policyId)
        {
            PolicyResponse policy = PolicyApplicationService.ReadPolicyById(policyId);

          //  List<CoveringTypeResponse> coveringTypes = CoveringTypeApplicationService.ReadCoveringTypes();
            ViewBag.PolicyName = policy.nombre;
            ViewBag.PolicyId = policy.id;
           // ViewBag.coveringTypes = new SelectList(coveringTypes, nameof(CoveringTypeResponse.id), nameof(PolicyResponse.nombre));
            return View("~/Views/Policies/AddCovering.cshtml");
        }

        [HttpPost]
        public ActionResult AddCovering(long policyId, string coveringName)
        {
            PolicyResponse policy = PolicyApplicationService.ReadPolicyById(policyId);
            try
            {
                PolicyRequest request = new PolicyRequest
                {
                    id = policy.id,
                    descripcion = policy.descripcion,
                    nombre = policy.nombre,
                    TSeg_Tipo_Cubrimiento = getCoveringTypes(policy, coveringName)
                };

                int response = PolicyApplicationService.UpdatePolicy(request);
                return RedirectToAction("Details", new { id = policyId });
            }
            catch
            {
                ViewBag.PolicyName = policy.nombre;
                ViewBag.PolicyId = policy.id;

                ViewBag.Error = "El tipo de cubrimiento no se pudo adicionar.";

                return View("~/Views/Policies/AddCovering.cshtml");
            }
        }

        public List<CoveringTypeResponse> getCoveringTypes(PolicyResponse policy, string newCoveringType)
        {
            List<CoveringTypeResponse> list = new List<CoveringTypeResponse>();
            foreach (CoveringTypeResponse tc in policy.TSeg_Tipo_Cubrimiento)
            {
                list.Add(new CoveringTypeResponse
                {
                    id = tc.id,
                    nombre = tc.nombre
                });
            }
            list.Add(new CoveringTypeResponse
            {
                nombre = newCoveringType

            });
            return list;
        }


    }
}