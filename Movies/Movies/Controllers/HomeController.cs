using Movies.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Movies.Controllers
    {
    public class HomeController : Controller
        {
        MovieContext _context;
        public HomeController()
            {
            _context = new MovieContext();
            }
        public ActionResult Index()
            {
            ViewBag.movies = _context.Movie.ToList();
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
        }
    }