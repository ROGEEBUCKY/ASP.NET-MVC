using BLL.BLServices;
using Common.ViewModels;
using System;
using System.Web.Mvc;

namespace OnlineMedicalBookingStore.Controllers
    {
    public class LoginController : Controller
        {
        readonly LoginServices _loginBObj;
        public LoginController()
            {
            _loginBObj = new LoginServices();
            }
        // GET: Login
        public ActionResult Index()
            {
            try
                {
                if (Session["User"] is UserVM user)
                    {
                    if (user.RoleId == 1)
                        return RedirectToAction("Index", "Admin");
                    else
                        {
                        return RedirectToAction("Index", "User");
                        }
                    }
                return View();

                }
            catch (Exception e)
                {
                Console.WriteLine(e);
                return View("Error");
                }
            }
        [HttpPost]
        public ActionResult Index(LoginVM logUser)
            {
            try
                {
                if (ModelState.IsValid)
                    {
                    var user = _loginBObj.LoginUser(logUser);
                    if (user == null)
                        {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View(logUser);
                        }

                    else
                        {
                        Session["User"] = user;
                        Session["UserId"] = user.Id;
                        if (user.RoleId == 1)
                            return RedirectToAction("Index", "Admin");
                        else if (user.RoleId == 2)
                            return RedirectToAction("Index", "User");
                        }
                    return View();
                    }
                else
                    {
                    return View(logUser);
                    }

                }
            catch (Exception e)
                {
                Console.WriteLine(e);
                return View("Error");
                }
            }
        public ActionResult Register()
            {
            return View();
            }
        [HttpPost]
        public ActionResult Register(UserVM newUser)
            {
            if (ModelState.IsValid)
                {
                _loginBObj.Register(newUser);
                @ViewBag.message = "Registered SuccessFully!";
                return View();
                }
            else
                {
                return View();
                }
            }

        [HttpPost]
        public JsonResult EmailAlreadyExist(string Email)
            {
            var checkMail = _loginBObj.CheckMail(Email);
            bool status;
            if (checkMail != null)
                {
                status = false;
                }
            else
                {
                status = true;
                }
            return Json(status, JsonRequestBehavior.AllowGet);
            }
        [Route("Login/NotFound")]
        public ActionResult UnAuthorize()
            {
            return View();
            }
        [HttpGet]
        [Route("Login/LogOut")]
        public ActionResult LogOut()
            {
            Session["User"] = string.Empty;
            Session["UserId"] = string.Empty;
            return RedirectToAction("Index");
            }
        }
    }