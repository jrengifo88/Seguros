using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices;
using TestSeguros.Models;
using TestSeguros.Validations;

namespace TestSeguros.Controllers
{
    public class CustomersController : Controller
    {
        CustomerApplicationService CustomerApplicationService;
        CustomerPolicyApplicationService CustomerPolicyApplicationService;
        PolicyApplicationService PolicyApplicationService;
        public CustomersController()
        {
            CustomerApplicationService = new CustomerApplicationService();
            PolicyApplicationService = new PolicyApplicationService();
            CustomerPolicyApplicationService = new CustomerPolicyApplicationService();
        }

        public ActionResult Customers()
        {
            List<CustomerResponse> model = CustomerApplicationService.ReadCustomers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View("~/Views/Customers/Create.cshtml");
        }

        [HttpPost]
        public ActionResult Create(CustomerRequest customer)
        {
            CustomerResponse response = CustomerApplicationService.CreateCustomer(customer);

            if (response.id > 0) return RedirectToAction("Customers");
            else
            {
                ViewBag.Error = "El cliente no pudo ser creado.";
                return View("~/Views/Customers/Create.cshtml");
            }
        }

        public ActionResult Delete(long id)
        {
            long response = CustomerApplicationService.DeleteCustomer(id);

            if (response > 0) return RedirectToAction("Customers");
            else
            {
                ViewBag.Error = "El cliente no pudo ser eliminado.";
                return View("~/Views/Customers/Customers.cshtml");
            }
        }


        public ActionResult PoliciesDetails(long id)
        {
            CustomerResponse customer = CustomerApplicationService.ReadCustomerById(id);
            CustomerPoliciesModelView model = new CustomerPoliciesModelView();
            model.customer = customer;
            model.policiesDetails = getPoliciesDetails(customer.policiesDetails);

            return View("~/Views/Customers/PoliciesDetails.cshtml", model);
        }

        public ActionResult AddPolicy(long customerId)
        {
            CustomerResponse customer = CustomerApplicationService.ReadCustomerById(customerId);

            List<PolicyResponse> policies = PolicyApplicationService.ReadPolicies();
            ViewBag.FullName = customer.apellidos + " " + customer.nombres;
            ViewBag.CustomerId = customer.id;
            ViewBag.Identification = customer.identificacion;
            ViewBag.policies = new SelectList(policies, nameof(PolicyResponse.id), nameof(PolicyResponse.nombre));
            return View("~/Views/Customers/AddPolicy.cshtml");
        }

        [HttpPost]
        public ActionResult AddPolicy(long customerId, long policyId, short meses, string riesgo, decimal precio, short cobertura)
        {
            try { 
            CustomerPolicyRequest customerPolicyRequest = new CustomerPolicyRequest
            {
                id_cliente = customerId,
                id_poliza = policyId,
                meses_cobertura = meses,
                riesgo =riesgo,
                precio = precio,
                cobertura = cobertura,
                fecha_inicio = DateTime.Now
            };

            CustomerPolicyValidation.validationsAddPolicy(customerPolicyRequest);

            CustomerPolicyResponse response = CustomerPolicyApplicationService.CreateCustomerPolicy(customerPolicyRequest);
             return RedirectToAction("PoliciesDetails", new { id = customerId });
            }
            catch
            {
                CustomerResponse customer = CustomerApplicationService.ReadCustomerById(customerId);
                ViewBag.FullName = customer.apellidos + " " + customer.nombres;
                ViewBag.CustomerId = customer.id;
                ViewBag.Identification = customer.identificacion;

                List<PolicyResponse> policies = PolicyApplicationService.ReadPolicies();
                ViewBag.policies = new SelectList(policies, nameof(PolicyResponse.id), nameof(PolicyResponse.nombre));

                ViewBag.Error = "La póliza no se pudo adicionar al cliente.";

                return View("~/Views/Customers/AddPolicy.cshtml");
            }
        }    

        public List<CustomerPolicyResponse> getPoliciesDetails(List<CustomerPolicyResponse> list)
        {
            for (int i=0; i<list.Count;i++)
            {
                PolicyResponse policy = PolicyApplicationService.ReadPolicyById(list.ElementAt(i).id_poliza);
                list.ElementAt(i).nombre_poliza = policy.nombre;
            }
            
            return list;
        }

        


    }
}