using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_XI.Controllers
    {
    public class HomeController : Controller
        {
        public ActionResult Index()
            {
            return View();
            }

        public ActionResult GetCalendarData()
            {
            JsonResult result = new JsonResult();
            try
                {
                List<PublicHoliday> data = this.LoadData();
                result = this.Json(data, JsonRequestBehavior.AllowGet);
                }
            catch(Exception ex)
                {
                Console.Write(ex);
                }
            return result;
            }

        private List<PublicHoliday> LoadData()
            {
            List<PublicHolidays> lst = new List<PublicHolidays>();
            try
                {

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