using BLL;
using System.Linq;
using System.Web.Mvc;

namespace ANIME.Controllers
    {
    public class AnimeController : Controller
        {
        readonly AnimeServices Blo;

        public AnimeController()
            {
            Blo = new AnimeServices();
            }

        // GET: Anime
        [Route("Anime/Index")]
        public ActionResult Index()
            {
             var list = Blo.GetAllAnime();
            return View(list);
            }

        [HttpGet]
        [Route("Anime/GetAnimeByName/{Name}")]
        public ActionResult GetAnimebyName(string name)
            {
            if (name == "All")
                {
                var aList = Blo.GetAllAnime();
                return View("Index", aList);
                }
            var list = Blo.GetAnimeByName(name);
            return View("Index", list);
            }
        }
    }