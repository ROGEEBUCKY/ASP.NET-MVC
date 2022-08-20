using BLL.BLServices;
using BLL.Security;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StaffDutyAllocation.Controllers
    {
    [CustomAuthenticationFilter]
    [CustomAuthorize("Admin")]
    public class AdminController : Controller
        {
        readonly UserServices userBObj;
        readonly DutyServices dutyBObj;
        readonly RosterServices rosterBObj;
        public AdminController()
            {
            userBObj = new UserServices();
            rosterBObj = new RosterServices();
            dutyBObj = new DutyServices();
            }




        // GET: Admin
        public ActionResult Index()
            {
            DutyVM newDuty = new DutyVM()
                {
                Categories = dutyBObj.GetAllCategories(),
                DutyType = dutyBObj.GetAllDutyTypes(),
                };
            ViewBag.dutymodel = newDuty;
            AdminVM info = dutyBObj.GetAllInfo();
            return View(info);
            }





        [HttpGet]
        public ActionResult Home()
            {
            AdminVM info = dutyBObj.GetAllInfo();
            return PartialView("_Home", info);
            }


        public ActionResult Employee()
            {
            return PartialView("_Employee");
            }




        public ActionResult Duties()
            {
            return PartialView("_Duty");
            }




        [HttpPost]
        public ActionResult AddDuty(DutyVM duty)
            {
            try
                {
                dutyBObj.AddNewDutyB(duty);
                }
            catch
                {
                return Json(new { success = false, message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
                }

            return PartialView("_Duty");
            }





        public ActionResult Roster()
            {
            return PartialView("_Roster");
            }
        [HttpPost]
        public JsonResult EmailAlreadyExist(string Email)
            {
            var checkMail = userBObj.GetAllUserB().FirstOrDefault(u => u.Email == Email);
            bool status;
            if (checkMail != null)
                {
                //Already registered  
                status = false;
                }
            else
                {
                //Available to use  
                status = true;
                }
            return Json(status, JsonRequestBehavior.AllowGet);
            }
        [HttpPost]
        public JsonResult UserIdAlreadyExist(string LoginId)
            {
            var user = userBObj.GetAllUserB().FirstOrDefault(u => u.LoginId == LoginId);
            bool status;
            if (user != null)
                {
                //Already registered  
                status = false;
                }
            else
                {
                //Available to use  
                status = true;
                }
            return Json(status, JsonRequestBehavior.AllowGet);
            }

        [HttpPost]
        public JsonResult RosterAlreadyExist(string Name)
            {
            var roster = rosterBObj.GetAllRosters().FirstOrDefault(u => u.Name == Name);
            bool status;
            if (roster != null)
                {
                //Already registered  
                status = false;
                }
            else
                {
                //Available to use  
                status = true;
                }
            return Json(status, JsonRequestBehavior.AllowGet);
            }




        public ActionResult Requests()
            {
            var requests = userBObj.GetAllEmployeeRequests();
            List<RequestVM> fList = requests.Select(r => new RequestVM()
                {
                Id = r.Id,
                DutyId = r.DutyId,
                UserId = r.UserId,
                CreatedDate =r.CreatedDate,
                Status = r.Status,
                Dutyname = r.Dutyname,
                UserName = r.UserName,
                Readstatus = "read"
                }).ToList();
            return PartialView("_Requests", fList);
            }

        [HttpPost]
        public ActionResult AcceptRequest(int requestId)
            {
            var request = userBObj.GetAllEmployeeRequests().FirstOrDefault(r => r.Id == requestId);
            userBObj.AcceptUserRequest(requestId);
            var msg = new MessageVM()
                {
                UserId = request.UserId,
                MessageText = "Your request is Accepted You will be unallocated from this duty.",
                Type = "admin"
                };
            userBObj.SendNewMessage(msg);
            return RedirectToAction("Messages");
            }



        [HttpPost]
        public ActionResult RejectRequest(int requestId)
            {
            var request = userBObj.GetAllEmployeeRequests().FirstOrDefault(r => r.Id == requestId);
            userBObj.AcceptUserRequest(requestId);
            var msg = new MessageVM()
                {
                UserId = request.UserId,
                MessageText = "Your request is Rejected.",
                Type = "admin"
                };
            userBObj.SendNewMessage(msg);
            return RedirectToAction("Messages");
            }




        [HttpGet]
        public ActionResult Messages()
            {
            ViewBag.msgUserList = userBObj.GetAllMessagedUsers();
            var firstUser = userBObj.GetAllMessagedUsers().First();
                var uMsgList = userBObj.GetUserMessageList(firstUser.UserId);
            ViewBag.firstusermessages = uMsgList.Select(x => new MessageVM()
                {
                Id = x.Id,
                UserId = x.UserId,
                UserName = x.UserName,
                MessageText = x.MessageText,
                Type= x.Type,
                CreatedTime = x.CreatedTime,
                Readstatus = "read"
                }).ToList();
            ViewBag.userName = firstUser.UserName;
            return PartialView("_Messages");
            }



        [HttpGet]
        public ActionResult GetEmployeeMessages(int id, string name)
            {
            ViewBag.userName = name;
            var mList = userBObj.GetUserMessageList(id);
            ViewBag.Message = mList;
            return PartialView("_EmployeeMessages");
            }


        [HttpPost]
        public ActionResult SendMessage(MessageVM newMessage, int id, string name)
            {
            newMessage.Type = "admin";
            newMessage.UserId = id;
            userBObj.SendNewMessage(newMessage);
            var mList = userBObj.GetUserMessageList(newMessage.UserId);
            ViewBag.Message = mList;
            ViewBag.userName = name;
            return PartialView("_EmployeeMessages");
            }
        [HttpPost]
        public ActionResult Register(UserVM user)
            {
            try
                {
                userBObj.AddNewUserB(user);
                }
            catch
                {
                return Json(new { success = false, message = "Something went wrong", }, JsonRequestBehavior.AllowGet);
                }

            return PartialView("_Employee");
            }
        [HttpGet]
        public ActionResult GetEmployee()
            {
            var list = userBObj.GetAllUserB();
            return Json(list, JsonRequestBehavior.AllowGet);
            }
        [HttpGet]
        public ActionResult AddNewEmployee()
            {
            UserVM user = new UserVM();
            return PartialView("_AddNewUser", user);
            }
        [HttpGet]
        public ActionResult GetDuties()
            {
            var dutyList = dutyBObj.GetAllDutiesB();
            return Json(dutyList, JsonRequestBehavior.AllowGet);
            }
        [HttpGet]
        public ActionResult AddNewDuty()
            {
            DutyVM newDuty = new DutyVM()
                {
                Categories = dutyBObj.GetAllCategories(),
                DutyType = dutyBObj.GetAllDutyTypes()
                };
            return PartialView("_AddDuty", newDuty);
            }
        public ActionResult AddNewRoster()
            {
            var roster = new RosterVM();
            return PartialView("_AddRoster", roster);
            }
        [HttpGet]
        public ActionResult GetRosters()
            {
            var rosterList = rosterBObj.GetAllRosters();
            return Json(rosterList, JsonRequestBehavior.AllowGet);
            }
        [HttpPost]
        public ActionResult AddRoster(RosterVM roster)
            {
            try
                {
                rosterBObj.AddNewRosterB(roster);
                }
            catch
                {
                return Json(false);
                }
            return PartialView("_Roster");
            }
        public ActionResult GetUnallocatedDuties()
            {
            var uDutyList = dutyBObj.GetAllUnAllocatedDuties();
            return Json(uDutyList, JsonRequestBehavior.AllowGet);
            }
        [HttpPost]
        public ActionResult AssignDuties(RosterVM roster)
            {
            try
                {
                dutyBObj.AssignNewDutiesB(roster);
                }
            catch (Exception e)
                {
                Console.WriteLine(e);
                }
            return PartialView("_Roster");
            }
        [HttpPost]
        public ActionResult AddDuties(int id)
            {
            var roster = rosterBObj.GetAllRosters().FirstOrDefault(r => r.Id == id);

            return PartialView("_AddDuties", roster);
            }

        [HttpPost]
        public ActionResult BlockEmployee(int id)
            {
            userBObj.BlockUser(id);
            return PartialView("_Employee");
            }
        [HttpPost]
        public ActionResult UnBlockUser(int id)
            {
            userBObj.UnBlockUser(id);
            return PartialView("_Employee");
            }
        public ActionResult BlockInActiveUsers()
            {
            var users = userBObj.GetAllUserB().Where(u => u.LastLoginTime.AddDays(3) < DateTime.Now);
            if (users != null)
                {
                foreach (var user in users)
                    {
                    user.IsBlocked = "true";
                    userBObj.AddNewUserB(user);
                    }
                }
            return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
