using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repository
    {
    public class UserRepository
        {
        readonly DBContext _context;
        public UserRepository()
            {
            _context = new DBContext();
            }

        public List<User> GetAllUsersForLogin()
            {
            try
                {
                return _context.Users.Include(u => u.Role).Where(u => u.IsBlocked != true).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        public User GetUserByID(int id)
            {
            try
                {
                return _context.Users.FirstOrDefault(u => u.Id == id);

                }
            catch (Exception)
                {

                throw;
                }
            }
        public void AddNewUser(User newUser)
            {
            try
                {
                _context.Users.AddOrUpdate(newUser);
                _context.SaveChanges();

                }
            catch (Exception)
                {

                throw;
                }
            }

        public List<Message> GetAllMessagedUsers()
            {
            try
                {
                var lastMessage = _context.Messages.Include(u => u.User).OrderByDescending(m => m.CreatedTime).ToList();
                var msgList = lastMessage.GroupBy(a => a.UserId).Select(a => a.First()).ToList();

                return msgList;

                }
            catch (Exception)
                {

                throw;
                }
            }

        public User CheckMail(string mail)
            {
            try
                {
                return _context.Users.FirstOrDefault(u => u.Email == mail);

                }
            catch (Exception)
                {

                throw;
                }
            }

        public void AddUpdateUser(User user)
            {
            try
                {
                _context.Users.AddOrUpdate(user);
                _context.SaveChanges();

                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Message> GetUserMessagesById(int id)
            {
            try
                {
                return _context.Messages.Where(m => m.UserId == id).OrderByDescending(m => m.CreatedTime).ToList();
                }
            catch (Exception)
                {

                throw;
                }
            }

        public void DeleteUserById(int id)
            {
            try
                {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                user.IsBlocked = true;
                _context.Users.AddOrUpdate(user);
                _context.SaveChanges();

                }
            catch (Exception)
                {

                throw;
                }
            }

        public void AddNewMessage(Message newMessage)
            {
            try
                {
                _context.Messages.Add(newMessage);
                _context.SaveChanges();

                }
            catch (Exception)
                {

                throw;
                }
            }

        public List<User> GetAllCustomers()
            {
            try
                {

                return _context.Users.Where(u => u.RoleId != 1 && u.IsBlocked == false).ToList();
                }
            catch (Exception)
                {

                throw;
                }
            }

        public Role GetUserRole(int id)
            {
            try
                {
                var userRole = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id).Role;
                return userRole;
                }
            catch (Exception)
                {

                throw;
                }
            }
        }
    }
