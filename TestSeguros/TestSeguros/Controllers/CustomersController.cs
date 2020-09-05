using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSeguros.Application.Request;
using TestSeguros.Application.Response;
using TestSeguros.ApplicationServices;

namespace TestSeguros.Controllers
{
    public class CustomersController : Controller
    {
        CustomerApplicationService CustomerApplicationService;
        public CustomersController()
        {
            CustomerApplicationService = new CustomerApplicationService();
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


    }
}