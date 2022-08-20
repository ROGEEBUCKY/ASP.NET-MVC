using AutoMapper;
using Common.ViewModels;
using DAL.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BLServices
    {
    public class UserServices
        {
        readonly UserRepository userDObj;
        readonly DutyRepository dutyDObj;
        public UserServices()
            {
            userDObj = new UserRepository();
            dutyDObj = new DutyRepository();
            }

        public void AddNewUserB(UserVM user)
            {
            User userD = Mapper.Map<UserVM, User>(user);
            userDObj.AddNewUserD(userD);
            }
        public List<UserVM> GetAllEmployeeB()
            {
            var list = userDObj.GetAllEmployeeD();
            return Mapper.Map<List<User>, List<UserVM>>(list);
            }

        public RosterVM GetUserRoster(int? id)
            {
            var roster = new RosterServices();
            var aDuty = dutyDObj.GetAllAssignedDuties().FirstOrDefault(d => d.UserId == id);
            if (aDuty == null)
                return null;
            var rost = roster.GetAllRosters().FirstOrDefault(r => r.Id == aDuty.RosterId);
            return rost;
            }

        public List<DutyVM> GetUserDuties(int? id)
            {
            var dutiesId = dutyDObj.GetAllAssignedDuties().Where(d => d.UserId == id).Select(d => d.DutyId).ToList();
            var userDuties = dutyDObj.GetAllDutiesD().Where(d => dutiesId.Contains(d.Id)).ToList();
            var VMList = Mapper.Map<List<Duty>, List<DutyVM>>(userDuties);
            foreach (var duty in VMList)
                {
                duty.DutyTypeName = dutyDObj.GetAllDutyTypes().FirstOrDefault(d => d.Id == duty.DutyTypeId).Name;
                }
            return VMList;
            }

        public void SendRequest(int userId, int dutyId)
            {
            var request = new RequestVM()
                {
                UserId = userId,
                DutyId = dutyId
                };
            var drequest = Mapper.Map<RequestVM, Request>(request);
            userDObj.AddNewRequest(drequest);
            }

        public List<UserVM> GetAllUserB()
            {
            var userList = userDObj.GetAllUsersD().Where(u => u.RoleId == 3).OrderByDescending(d => d.CreatedDate).ToList();
            return Mapper.Map<List<User>, List<UserVM>>(userList);
            }

        public List<RequestVM> GetAllEmployeeRequests()
            {
            var requestList = userDObj.GetAllRequests();
            var vRequests = requestList.Select(r => new RequestVM()
                {
                Id = r.Id,
                CreatedDate = r.CreatedDate,
                UserId = r.UserId,
                DutyId = r.DutyId,
                Status = r.Status,
                UserName = userDObj.GetAllEmployeeD().FirstOrDefault(u => u.Id == r.UserId).FirstName + " " + userDObj.GetAllEmployeeD().FirstOrDefault(u => u.Id == r.UserId).LastName,
                Dutyname = dutyDObj.GetAllDutiesD().FirstOrDefault(d => d.Id == r.DutyId).Name
                }).ToList();
            return vRequests;
            }

        public void AcceptUserRequest(int requestId)
            {
            var request = GetAllEmployeeRequests().FirstOrDefault(r => r.Id == requestId);
            var assignedDuty = dutyDObj.GetAllAssignedDuties().FirstOrDefault(d => d.DutyId == request.DutyId);
            assignedDuty.UserId = null;
            dutyDObj.AssignDuty(assignedDuty);
            request.Status = "Acccepted";
            var dRequest = Mapper.Map<RequestVM, Request>(request);
            userDObj.AddNewRequest(dRequest);
            }

        public void RejectUserRequest(int requestId)
            {
            var request = GetAllEmployeeRequests().FirstOrDefault(r => r.Id == requestId);
            request.Status = "Rejected";
            var dRequest = Mapper.Map<RequestVM, Request>(request);
            userDObj.AddNewRequest(dRequest);
            }

        public void UnBlockUser(int id)
            {
            userDObj.UnBlockUser(id);
            }

        public List<MessageVM> GetUserMessageList(int? id)
            {
            var mList = userDObj.GetUserMessageList(id);
            return Mapper.Map<List<Message>, List<MessageVM>>(mList);
            }

        public void SendNewMessage(MessageVM newMessage)
            {
            var msg = Mapper.Map<MessageVM, Message>(newMessage);
            userDObj.AddNewMessage(msg);
            }
        public List<EmployeeMessagesVM> GetAllMessagedUsers()
            {
            var messageList = userDObj.GetAllmessages();
            var Employees = userDObj.GetAllEmployeeD();

            var users = (from e in Employees
                         join m in messageList on e.Id equals m.UserId
                         select new EmployeeMessagesVM()
                             {
                             UserId = m.UserId,
                             UserName = e.FirstName + " " + e.LastName,
                             MessageCreatedTime = m.CreatedTime
                             }).OrderByDescending(u => u.MessageCreatedTime).ToList();


            return users.GroupBy(u => u.UserId).Select(s => s.First()).ToList();
            }

        public void BlockUser(int id)
            {
            userDObj.BlockUserD(id);
            }

        public bool CheckUserDutyAssignment(int userId, int dutyId)
            {
            var dutyType = dutyDObj.GetAllDutiesD().FirstOrDefault(d => d.Id == dutyId).Type;
            var assDuty = dutyDObj.GetAssignedDutieslist().Where(d => d.UserId == userId).ToList();
            if (assDuty == null)
                {
                return true;
                }
            else
                {
                    if (assDuty.Count() >= 3)
                        {
                        return false;
                        }
                    else
                        {
                        foreach (var d in assDuty)
                            {
                            if (d.DutyType == "Full Day")
                                {
                                return false;
                                }
                            else if (d.DutyType == "Hourly" && dutyType.Name == "Hourly")
                                {
                                return true;
                                }
                            else
                                {
                                return false;
                                }
                            }
                        return true;
                        }
                }
            }
        }
    }
