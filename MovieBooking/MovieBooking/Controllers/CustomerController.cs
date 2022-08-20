using MovieBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBooking.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController()
            {

            }
        // GET: Customer
        [Route("Customer/Register")]
        public ActionResult Register()
        {
            return View();
        }

        // save:Customer Data into Json File
        [HttpPost]
        public ActionResult FormCollecting(Customer m)
            {
            if (!ModelState.IsValid)
                {
                return View("Register",m);
                }
            Models.Register.RegisterCustomer(m);

            return RedirectToRoute(new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            }
    }
}