using COMMON.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Details()
        {
            EmployeeVM employee = new EmployeeVM()
                {
                EmployeeId = 1,
                Name = "John",
                Gender = "Male",
                City = "London"
                };
            return View(employee);
        }
    }
}