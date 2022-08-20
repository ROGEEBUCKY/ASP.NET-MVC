using BLL;
using Common;
using System.Collections.Generic;
using System;
using System.Web.Mvc;

namespace ANIME.Controllers
    {
    public class HomeController : Controller
        {
        public ActionResult Index()
            {
            var BLO = new AnimeServices();
            var list = BLO.GetSomeAnime();
            ViewBag.AnimeList = list;
            return View();
            }

        public ActionResult Anime()
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