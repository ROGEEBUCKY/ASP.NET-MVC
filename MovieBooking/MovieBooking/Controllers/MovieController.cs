using MovieBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBooking.Controllers
    {
    public class MovieController : Controller
        {
        private readonly JsonF jsonData;

        public MovieController()
            
            {
             jsonData = new JsonF();
            }


        // GET: Movie
        [Route("Movie/MovieDetails/{id}")]
        public ActionResult MovieDetails(int id)
            {
            var movieObject = jsonData.GetJson().movies.FirstOrDefault(x => x.id == id);
            return View(movieObject);
            }
        }
    }