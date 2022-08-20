using BLL.BLServices;
using Common.ViewModels;
using System.Web.Mvc;

namespace OnlineMedicalBookingStore.Controllers
    {
    public class HomeController : Controller
        {
        readonly ProductServices _productBObj;
        public HomeController()
            {
            _productBObj = new ProductServices();
            }
        public ActionResult Index()
            {
            UserVM user = Session["User"] as UserVM;
            if (user != null)
                {
                if (user.RoleId == 1)
                    return RedirectToAction("Index", "Admin");
                else
                    {
                    return RedirectToAction("Index", "User");
                    }
                }
            var list = _productBObj.GetSomeProducts(9);
            ViewBag.products = list;
            return View();
            }
        }
    }