using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var DB = new UserContext();
            List<User> userlist = DB.Users.ToList();
            return View(userlist);
        }
        public ActionResult AddUser( int id = 0)
            {
            if(id == 0)
                {
                return View();
                }
            var DB = new UserContext();
            var user = DB.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
            }
        [HttpPost]
        public ActionResult AddUser(User user)
            {
            if (!ModelState.IsValid)
                {
                    return View(user);
                }
            var DB = new UserContext();
            DB.Users.AddOrUpdate(user);
            DB.SaveChanges();
            return RedirectToAction("Index");  
            }
    }
}