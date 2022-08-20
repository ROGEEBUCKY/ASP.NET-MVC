using AutoMapper;
using Common.ViewModels;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BLServices
    {
    public class DutyServices
        {
        readonly DutyRepository dutyDObj;
        readonly UserRepository userDObj;
        readonly RosterRepository rosterDObj;
        public DutyServices()
            {
            userDObj = new UserRepository();
            dutyDObj = new DutyRepository();
            rosterDObj = new RosterRepository();
            }

        public void AddNewDutyB(DutyVM Duty)
            {
            Duty dutyD = Mapper.Map<DutyVM, Duty>(Duty);
            dutyDObj.AddNewDutyD(dutyD);
            }
        public List<DutyVM> GetAllDutiesB()
            {
            var listD = dutyDObj.GetAllDutiesD();
            List<DutyVM> dutyVMList = listD.Select(d => new DutyVM()
                {
                Id = d.Id,
                Name = d.Name,
                DutyTypeName = d.Type.Name,
                CategoryName = d.Category.Name,
                CreatedDate = d.CreatedDate,
                UserId = GetAssignedUserToDuty(d.Id).Id,
                UserName = GetAssignedUserToDuty(d.Id).FirstName+" "+GetAssignedUserToDuty(d.Id).LastName
                }).ToList();

            return dutyVMList;
            }
        public List<DutyVM> GetAllUnAllocatedDuties()
            {
            var listD = dutyDObj.GetAllUnAllocatedDutiesD();
            var listB = Mapper.Map<List<Duty>, List<DutyVM>>(listD);
            return listB;
            }

        public AdminVM GetAllInfo()
            {
            var dutylist = Mapper.Map<List<Duty>, List<DutyVM>>(dutyDObj.GetAllDutiesD());
            var assignedduties = dutyDObj.GetAssignedDutieslist();
            var listD = Mapper.Map<List<Duty>, List<DutyVM>>(dutyDObj.GetAllUnAllocatedDutiesD());
            var usedduties = (from x in assignedduties
                              join y in dutylist on x.DutyId equals y.Id
                              select y).ToList();

            var usedRosterID = (from x in assignedduties
                                select x.RosterId).ToList();

            var emptyRosters = rosterDObj.GetAllRosters().Where(r => !usedRosterID.Contains(r.Id)).ToList();
            var unReadMsgs = userDObj.GetAllmessages().Where(m => m.Type == "user" ).Count();
            AdminVM adminVM = new AdminVM()
                {
                Duties = dutylist,
                AssignedDuties = usedduties,
                UnAssignedDuties = listD,
                Employees = Mapper.Map<List<User>, List<UserVM>>(userDObj.GetAllEmployeeD().ToList()),
                Users = Mapper.Map<List<User>, List<UserVM>>(userDObj.GetAllUsersD().Where(u => u.RoleId == 2).ToList()),
                Rosters = Mapper.Map<List<Roster>, List<RosterVM>>(rosterDObj.GetAllRosters().ToList()),
                EmptyRosters = Mapper.Map<List<Roster>, List<RosterVM>>(emptyRosters),
                Umsg = unReadMsgs,
                };
            return adminVM;
            }

        public void AssignNewDutiesB(RosterVM roster)
            {
            if (roster.SelectedDutyId == null)
                {
                var assignedDuties = dutyDObj.GetAssignedDutieslist().Where(d => d.RosterId == roster.Id).ToList();
                foreach (var aduty in assignedDuties)
                    {
                    dutyDObj.UnAssignDuty(aduty.Id);
                    }
                }
            else
                {
                var assignedDuties = dutyDObj.GetAssignedDutieslist().Where(d => d.RosterId == roster.Id).ToList();
                var rosterAssignedDuties = assignedDuties.Where(asd => !roster.SelectedDutyId.Contains(asd.DutyId)).ToList();
                foreach (var aduty in rosterAssignedDuties)
                    {
                    dutyDObj.UnAssignDuty(aduty.Id);
                    }
                var selectedDuties = dutyDObj.GetAllUnAllocatedDutiesD().Where(d => roster.SelectedDutyId.Contains(d.Id)).ToList();
                foreach (var duty in selectedDuties)
                    {
                    var assignedDuty = new AssignedDuties()
                        {
                        RosterId = roster.Id,
                        DutyId = duty.Id,
                        AssignedTime = DateTime.Now
                        };
                    dutyDObj.AssignDuty(assignedDuty);
                    }
                }
            }

        public List<DutyVM> GetAllAssignedDutiesToRoster(int id)
            {
            var list = dutyDObj.GetAssignedDutieslist().Where(r => r.RosterId == id);
            var dutyList = GetAllDutiesB();
            var rosterDutyList = (from x in list
                                  join y in dutyList on x.DutyId equals y.Id
                                  select y).ToList();

            return rosterDutyList;
            }

        public List<CategoryVM> GetAllCategories()
            {
            return Mapper.Map<List<Category>, List<CategoryVM>>(dutyDObj.GetAllCategoriesD());
            }
        public List<DutyTypeVM> GetAllDutyTypes()
            {
            return Mapper.Map<List<DutyType>, List<DutyTypeVM>>(dutyDObj.GetAllDutyTypes());
            }

        public void AssignDutyToUser(int userId, int dutyId, int rosterId)
            {
            var assigneDuty = GetAllAssignedDuties().FirstOrDefault(ad => ad.DutyId == dutyId);
            var dduty = dutyDObj.GetAllDutiesD().FirstOrDefault(d => d.Id == dutyId);
            if (assigneDuty == null)
                {
                var asduty = new AssignedDuties()
                    {
                    UserId = userId,
                    DutyId = dutyId,
                    RosterId = rosterId,
                    AssignedTime = DateTime.Now,
                    DutyType = dduty.Type.Name
                    };
                dutyDObj.AssignDuty(asduty);
                }
            else
                {
                assigneDuty.UserId = userId;
                var aduty = Mapper.Map<AssignedDutiesVM, AssignedDuties>(assigneDuty);
                aduty.DutyType = dduty.Type.Name;
                dutyDObj.AssignDuty(aduty);
                }
            }
        public UserVM GetAssignedUserToDuty(int id)
            {
            var asDuty = dutyDObj.GetAssignedDutieslist().FirstOrDefault(d => d.DutyId == id);
            if (asDuty == null)
                return new UserVM();

            User user = userDObj.GetAllEmployeeD().FirstOrDefault(e => e.Id == asDuty.UserId);
            if (user == null)
                return new UserVM();

            return Mapper.Map<User, UserVM>(user);
            }

        public List<AssignedDutiesVM> GetAllAssignedDuties()
            {
            var list = dutyDObj.GetAssignedDutieslist();
            return Mapper.Map<List<AssignedDuties>, List<AssignedDutiesVM>>(list);
            }

        }
    }
