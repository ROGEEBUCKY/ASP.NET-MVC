using Common.ViewModels;
using System.Web.Mvc;

namespace PersonalTradingSystem.Controllers
    {
    public class HomeController : Controller
        {
        public HomeController()
            {

            }
        public ActionResult Index()
            {
            if (Session["User"] == null)
                {
                return View();

                }
            else
                {
                UserVM u = Session["User"] as UserVM;
                if (u.RoleId == 3)
                    return RedirectToAction("Index", "User");
                else
                    return RedirectToAction("Index", "Admin");
                }
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