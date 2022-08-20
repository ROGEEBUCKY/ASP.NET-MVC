using System.Web.Mvc;

namespace Session.Controllers
    {
    public class HomeController : Controller
        {
        public ActionResult Index()
            {
            string[] Students = { "Aditya", "Sachin", "Arun" };
            ViewData["var1"] = "Data comes from ViewData";
            ViewBag.Var2 = "Data comes from ViewBag";
            TempData["Var3"] = "Data comes from TempData";
            Session["var4"] = null;
            Session["var5"] = Students;
            return View();
            }


        public ActionResult About()
            {
            if (Session["var4"] != null)
                {
                Session["var4"].ToString();
                }
            ViewBag.Message = "Your application description page.";

            return View();
            }

        public ActionResult Contact()
            {
            if (Session["var4"] != null)
                {
                Session["var4"].ToString();
                }
            ViewBag.Message = "Your contact page.";

            return View();
            }
        }
    }