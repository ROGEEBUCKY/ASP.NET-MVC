using AutoMapper;
using Common.ViewModels;
using DAL.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BLServices
    {
    public class RosterServices
        {
        readonly RosterRepository rosterDObj;
        readonly DutyRepository dutyDObj;
        readonly UserRepository userDObj;
        public RosterServices()
            {
            userDObj = new UserRepository();
            dutyDObj = new DutyRepository();
            rosterDObj = new RosterRepository();
            }

        public void AddNewRosterB(RosterVM roster)
            {
            Roster dRoster = Mapper.Map<RosterVM, Roster>(roster);
            rosterDObj.AddNewRoster(dRoster);


            }
        public List<RosterVM> GetAllRosters()
            {
            var uDuty = dutyDObj.GetAllUnAllocatedDutiesD();
            var list = rosterDObj.GetAllRosters().Select(r => new RosterVM()
                {
                Id = r.Id,
                Name = r.Name,
                CreatedDate = r.CreatedDate,
                NumberOfDuties = dutyDObj.GetRosterAssignedDuties(r.Id),
                SelectedDutyId = dutyDObj.GetAssignedDutieslist()
                                         .Where(d => d.RosterId == r.Id)
                                         .Select(d => d.DutyId)
                                         .ToArray(),
                UnAssignedUsers = GetAllAssignedEmployeesToRoster(r.Id)
                }).ToList();

            foreach (var roster in list)
                {
                var dlist = dutyDObj.GetAllDutiesD().Where(d => roster.SelectedDutyId.Contains(d.Id)).ToList();
                roster.ListOfDuties = Mapper.Map<List<Duty>, List<DutyVM>>(dlist);
                roster.ListOfDuties.AddRange(Mapper.Map<List<Duty>, List<DutyVM>>(uDuty));
                }
            return list;
            }
        public RosterVM GetARosterById(int id)
            {
            var roster = GetAllRosters().FirstOrDefault(r => r.Id == id);
            return roster;
            }
        public List<UserVM> GetAllAssignedEmployeesToRoster(int id)
            {

            var userList = dutyDObj.GetAllAssignedDuties()
                                   .Where(d => d.RosterId == id).GroupBy(p => p.UserId)
                                   .Select(g =>g.First()).Select(d => d.User).ToList();
            var uAssignedUsers = userDObj.GetAllUnAssignedUsers().ToList();
            var newUserList = uAssignedUsers;
            foreach(var user in userList)
                {
                if(user != null)
                newUserList.Add(user);
                }
            return Mapper.Map<List<User>, List<UserVM>>(newUserList);
            }

        }
    }
