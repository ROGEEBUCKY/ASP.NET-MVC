using BLL.BLServices;
using BLL.Security;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffDutyAllocation.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorize("Employee")]
    public class EmployeeController : Controller
    {
        readonly UserServices userBObj;
        readonly DutyServices dutyBObj;
        public EmployeeController()
            {
            userBObj = new UserServices();
            dutyBObj = new DutyServices();
            }
        // GET: Employee
        public ActionResult Index()
        {
            var user = Session["User"] as UserVM;
            var roster = userBObj.GetUserRoster(user.Id);
            var UserDuties = userBObj.GetUserDuties(user.Id);
            ViewBag.dutylist = UserDuties;
            return View(roster);
        }
        public ActionResult Home()
            {
            var user = Session["User"] as UserVM;
            var UserDuties = userBObj.GetUserDuties(user.Id);
            ViewBag.duties = UserDuties;
            return PartialView("_EmployeeHome");
            }
        [HttpGet]
        public ActionResult Message()
            {
            UserVM user = Session["User"] as UserVM;
            var mList = userBObj.GetUserMessageList(user.Id);
            ViewBag.Message = mList;
            return PartialView("_Message");
            }
        [HttpPost]
        public ActionResult SendMessage(MessageVM newMessage)
            {
            userBObj.SendNewMessage(newMessage);
            return RedirectToAction("Message");
            }
        [HttpPost]
        public ActionResult SendRequest(int userId,int dutyId)
            {
            var duty = dutyBObj.GetAllDutiesB().FirstOrDefault(d => d.Id == dutyId);
            userBObj.SendRequest(userId,dutyId);
            var msg = new MessageVM()
                {
                UserId = userId,
                MessageText = "Hello Admin, I have completed this duty: " + duty.Name + ".Please unallocate me from this duty",
                Type = "user"
                };
            userBObj.SendNewMessage(msg);
            return RedirectToAction("Message");
            }
        [HttpPost]
        public ActionResult CheckRequest(int userId, int dutyId)
            {
            var request = userBObj.GetAllEmployeeRequests().FirstOrDefault(r => r.UserId == userId && r.DutyId == dutyId);
            if(request == null)
                {
                return Json(true,JsonRequestBehavior.AllowGet);
                }
            else if(request.Status == "pending")
                {
                return Json(false, JsonRequestBehavior.AllowGet);
                }
            return Json(true,JsonRequestBehavior.AllowGet);
            }
        }
}