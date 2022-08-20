using BLL.BLServices;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalTradingSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["User"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
            else
                {
                UserVM u = Session["User"] as UserVM;
                if (u.RoleId == 3)
                    return RedirectToAction("Index", "User");
                else
                    return View();
                }
        }
        [HttpPost]
        public ActionResult GetaUser(int id)
            {
            UserServices s = new UserServices();
            UserVM user = s.GetUserById(id);
            return PartialView(@"~/Views/Admin/_User.cshtml", user);
            }

    }
}