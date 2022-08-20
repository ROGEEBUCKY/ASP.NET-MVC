using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repository
    {
    public class UserRepository
        {
        public readonly AppDBContext _Context;
        public UserRepository()
            {
            _Context = new AppDBContext();
            }

        public void AddNewUserD(User user)
            {
            _Context.Users.AddOrUpdate(user);
            _Context.SaveChanges();
            }
        public IEnumerable<User> GetAllUsersD()
            {
            return _Context.Users.ToList();
            }
        public User GetAUserByID(int id)
            {
            return _Context.Users.FirstOrDefault(u => u.Id == id);
            }
        public Role GetUserRoleD(int id)
            {
            var user = _Context.Users.FirstOrDefault(u => u.Id == id);
            var role = _Context.Roles.FirstOrDefault(r => r.Id == user.RoleId);
            return role;
            }

        public void UnBlockUser(int id)
            {
            var user = _Context.Users.Where(u => u.Id == id).FirstOrDefault();
            user.IsBlocked = "false";
            _Context.Users.AddOrUpdate(user);
            _Context.SaveChanges();
            }

        

        public List<Message> GetUserMessageList(int? id)
            {
            return _Context.Messages.Where(m => m.UserId == id).OrderByDescending(m => m.CreatedTime).ToList();
            }

        public List<Message> GetAllmessages()
            {
            var list = _Context.Messages.ToList();
            return list;
            }

        public void AddNewMessage(Message msg)
            {
            _Context.Messages.Add(msg);
            _Context.SaveChanges();
            }

        public void BlockUserD(int id)
            {
            var user = _Context.Users.Where(u => u.Id == id).FirstOrDefault();
            user.IsBlocked = "true";
            _Context.Users.AddOrUpdate(user);
            _Context.SaveChanges();
            }
        public List<User> GetAllEmployeeD()
            {
            var list = _Context.Users.Where(e => e.RoleId == 3 && e.IsBlocked != "true").ToList();
            return list;
            }

        public List<Request> GetAllRequests()
            {
            var requests = _Context.Requests.Where(r => r.Status == "pending").ToList();
            return requests;
            }

        public void AddNewRequest(Request drequest)
            {
            _Context.Requests.AddOrUpdate(drequest);
            _Context.SaveChanges();
            }

        public List<User> GetAllUnAssignedUsers()
            {
            var userList = GetAllEmployeeD();
            var assDuty = _Context.AssignedDuties.Select(d => d.UserId).ToList();
            var unAssignedUsers = userList.Where(d => !assDuty.Contains(d.Id)).ToList();
            return unAssignedUsers;
            }
        
        }
    }
