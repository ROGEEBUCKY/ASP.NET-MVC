using Project2.Models;
using System.Linq;
using System.Web.Mvc;

namespace Project2.Controllers
    {
    public class CustomersController : Controller
        {
        private MovieContext _Context;
        public CustomersController()
            {
            _Context = new MovieContext();
            }
        protected override void Dispose(bool disposing)
            {
            _Context.Dispose();
            }

        // GET: Customers
        public ActionResult Index()
            {
            var customers = _Context.Customers;
            return View(customers);
            }

        [Route("Customer/Form")]
        public ActionResult New()
            {
            var membershipTypes = _Context.MembershipTypes.ToList();

            return View();
            }
        public ActionResult Create(FormCollection collect)
            {

            return RedirectToAction("index","Home");
            }

        }
    }