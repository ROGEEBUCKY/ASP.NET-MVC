using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
    {

    public class UserController : Controller
        {
        ProjectContext _Context;
        public UserController()
            {
            _Context = new ProjectContext();
            }
        // GET: User

        public ActionResult Details()
            {
            return View(_Context.Users);
            }

        public ActionResult Index()
            {
            return View();
            }



        [ValidateAntiForgeryToken]
        public ActionResult FormCollecting(User emp)
            {
            if (ModelState.IsValid)
                {
                _Context.Users.AddOrUpdate(emp);
                }
            else
                {
                return View("Index", emp);
                }
            _Context.SaveChanges();
            return RedirectToAction("Details");
            }

        public ActionResult Delete(int id)
            {
            var user = _Context.Users.SingleOrDefault(x => x.Id == id);
            _Context.Users.Remove(user);
            _Context.SaveChanges();
            return RedirectToAction("Details");
            }

        public ActionResult Edit(int id)
            {
            User user = _Context.Users.SingleOrDefault(x => x.Id == id);
            return View("Index", user);
            }
        }
    }