using BLL.BLServices;
using Common.ViewModels;
using System.Web.Mvc;

namespace PersonalTradingSystem.Controllers
    {
    public class LoginController : Controller
        {
        public LoginController()
            {

            }
        // GET: Login
        public ActionResult Index()
            {
            if (Session["User"] == null)
                {
                return View();
                }
            else
                {
                return RedirectToAction("Index", "User");
                }
            }

        [HttpPost]
        public ActionResult Index(LoginVM loguser)
            {
            if (ModelState.IsValid)
                {
                var Bobj = new LoginServices();
                var user = Bobj.Login(loguser);
                if (user != null)
                    {
                    Session["User"] = user;
                    if (user.RoleId == 1 || user.RoleId == 2)
                        return RedirectToAction("Index", "Admin");
                    else
                        return RedirectToAction("Index", "User");
                    }
                else
                    {
                    ModelState.AddModelError("", "Invalid Email or Password");
                    return View(loguser);
                    }
                }
            else
                {
                return View(loguser);
                }
            }
        public ActionResult Register()
            {
            if (Session["User"] == null)
                {

                return View();
                }
            else
                {
                return RedirectToAction("Index", "User");
                }
            }

        [HttpPost]
        public ActionResult Register(UserVM user)
            {
            if (!ModelState.IsValid)
                {
                return View("Register", user);
                }
            else
                {
                if (user.Id != 0)
                    {
                    var Userobj1 = new UserServices();
                    Userobj1.AddUser(user);
                    return Json(user,JsonRequestBehavior.AllowGet);
                    }
                    var Userobj = new UserServices();
                    Userobj.AddUser(user);
                    ViewBag.message = "Now you can start Trading!";
                    return View();
                }
            }

        [Route("Login/LogOff1")]
        public ActionResult LogOff()
            {
            Session["User"] = null;
            Session.Clear();
            return RedirectToAction("Index", "Home");
            }

        [HttpPost]
        public JsonResult IsAlreadySignedUpStudent(string Email)
            {
            var Bobj = new LoginServices();

            var status = Bobj.CheckUser(Email);

            return Json(!status); ;
            }
        }
    }