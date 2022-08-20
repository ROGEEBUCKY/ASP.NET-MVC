using MovieBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBooking.Controllers
    {
    public class HomeController : Controller
        {
        public HomeController()
            {

            }
        public ActionResult Index()
            {
            var j = new JsonF();
            string output = Request["search"];
            var movies = j.GetJson().movies;
            if (!string.IsNullOrEmpty(output))
                movies = movies.Where(x => x.title.ToLower().StartsWith(output.ToLower())).ToList();
            return View(movies);
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
        }
    }