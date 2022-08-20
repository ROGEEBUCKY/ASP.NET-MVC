using BLL.BLServices;
using Common.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services;

namespace StaffDutyAllocation.Controllers
    {
    public class LoginController : Controller
        {
        readonly LoginServices loginBObj;
        readonly UserServices userBObj;
        public LoginController()
            {
            userBObj = new UserServices();
            loginBObj = new LoginServices();
            }
        // GET: Login
        public ActionResult Index()
            {
            return View();
            }
        [HttpPost]
        public ActionResult Index(LoginVM logUser)
            {
            if (ModelState.IsValid)
                {
                var user = loginBObj.LoginUserB(logUser);
                if (user == null)
                    {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View(logUser);
                    }
                else
                    {
                    user.LastLoginTime = DateTime.Now;
                    userBObj.AddNewUserB(user);
                    Session["User"] = user;
                    Session["UserId"] = user.Id;
                    if (user.RoleId == 1)
                        return RedirectToAction("Index", "Admin");
                    else if (user.RoleId == 2)
                        return RedirectToAction("Index", "User");
                    else
                        return RedirectToAction("Index", "Employee");
                    }
                }
            else
                {
                return View(logUser);
                }
            }
        public ActionResult UnAuthorized()
            {
            var u = Session["User"] as UserVM;
            return View(u);
            }
        [HttpGet]
        public ActionResult LogOut()
            {
            UserVM user = Session["User"] as UserVM;
            Session ["User"] = string.Empty;
            Session ["UserId"] = string.Empty;
            return RedirectToAction("Index");
            }
    
        }
    }