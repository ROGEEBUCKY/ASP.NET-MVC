using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers
    {
    public class MoviesController : Controller
        {
        private readonly List<Customer> customers;
        public MoviesController()
            {
            CustomerList customer = new CustomerList();
            customers = customer.Customers;
            }
        public ActionResult Customer()
            {
            var customer = new CustomerList();
            return View(customer);
            //return View(customers);
            }
        [HttpGet]
        [Route("Movies/Customers/{id}")]
        public ActionResult _getCustomerBYID(int id)
            {
            var customer = customers.FirstOrDefault(x => x.Id == id);
            return View(customer);
            }
        }
    }