using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authorize.Controllers
    {
    public class HomeController : Controller
        {
        public ActionResult Index()
            {
            return View();
            }

        public ActionResult About()
            {
            ViewBag.Message = "Your application description page.";

            return View();
            }

        public ActionResult Contact()
            {
            ViewBag.Message = "Your contact page.";

            return View();
            }
        [AllowAnonymous]
        public ActionResult NonSecured()
            {
            return View();
            }
        [Authorize]
        public ActionResult Secured()
            {
            return View();
            }

        public ActionResult Login()
            {
            return View();
            }
        }
    }