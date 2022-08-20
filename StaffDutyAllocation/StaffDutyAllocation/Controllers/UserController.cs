using BLL.BLServices;
using BLL.Security;
using Common.CommonServices;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StaffDutyAllocation.Controllers
    {

    [CustomAuthenticationFilter]
    [CustomAuthorize("User")]
    public class UserController : Controller
        {
        readonly RosterServices rosterBObj;
        readonly UserServices userBObj;
        readonly DutyServices dutyBObj;
        readonly MailService mailBObj;
        public UserController()
            {
            mailBObj = new MailService();
            userBObj = new UserServices();
            rosterBObj = new RosterServices();
            dutyBObj = new DutyServices();
            }
        public ActionResult Index()
            {
            var list = rosterBObj.GetAllRosters().Where(r => r.NumberOfDuties != 0).ToList();
            ViewBag.rlist = list;
            return View();
            }
        [HttpGet]
        public ActionResult Home()
            {
            var list = rosterBObj.GetAllRosters().Where(r => r.NumberOfDuties != 0).ToList();
            return PartialView("_UserHome", list);
            }
        public ActionResult Employee()
            {
            return PartialView("_Employee");
            }
        [HttpGet]
        public ActionResult GetEmployees()
            {
            var list = userBObj.GetAllEmployeeB();
            return Json(list, JsonRequestBehavior.AllowGet);
            }

        [HttpPost]
        public ActionResult GetRosterDuties(int id)
            {
            var roster = rosterBObj.GetARosterById(id);
            var list = dutyBObj.GetAllAssignedDutiesToRoster(id).ToArray();
            foreach (var duty in list)
                {
                duty.Users.AddRange(roster.UnAssignedUsers);
                }
            return Json(list, JsonRequestBehavior.AllowGet);
            }
        [HttpPost]
        public ActionResult OpenRosterModal(int id)
            {
            var roster = rosterBObj.GetARosterById(id);
            return PartialView("_DutyList", roster);
            }

        [HttpPost]
        public ActionResult BlockUser(int id)
            {
            userBObj.BlockUser(id);
            return PartialView("_Employee");
            }
        [HttpPost]
        public void AssignUser(int userId, int dutyId, int rosterId)
            {
            dutyBObj.AssignDutyToUser(userId, dutyId, rosterId);
            }
        [HttpPost]
        public ActionResult CheckDutyAssignment(int userId, int dutyId)
            {
            var result = userBObj.CheckUserDutyAssignment(userId, dutyId);
            return Json(result, JsonRequestBehavior.AllowGet);
            }
        [HttpPost]
        public void SendMailToEmployees(List<int> data)
            {
            foreach(var id in data)
                {
                var user = userBObj.GetAllEmployeeB().FirstOrDefault(e => e.Id == id);
                var assignedDuties = dutyBObj.GetAllAssignedDuties().Where(d => d.UserId == id).Count();
                var rosterId = dutyBObj.GetAllAssignedDuties().FirstOrDefault(d => d.UserId == id).RosterId;
                var roster = rosterBObj.GetARosterById(rosterId);
                var msg = "Hello " + user.FirstName + ", you are assigned to '" + roster.Name + "' Roster today. You are allocated to " + assignedDuties + " duties.Please perform your duties responsively.";
                mailBObj.SendMail(user.Email, msg);
                }
            }
        }
    }