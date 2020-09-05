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
    public class CustomersController : Controller
    {
        CustomerApplicationService CustomerApplicationService;
        PolicyApplicationService PolicyApplicationService;
        public CustomersController()
        {
            CustomerApplicationService = new CustomerApplicationService();
            PolicyApplicationService = new PolicyApplicationService();
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