using DAL.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repository
    {
    public class UserRepository
        {
        private readonly TradingContext _Context;
        public UserRepository()
            {
            _Context = new TradingContext();
            }

        public void AddUser(User newUser)
            {
            _Context.Users.AddOrUpdate(newUser);
            _Context.SaveChanges();
            }

        public List<User> GetAllUser()
            {
            var list = _Context.Users.ToList();
            return list;
            }

        public User GetUserById(int id)
            {
            return _Context.Users.SingleOrDefault(u => u.Id == id);
            }
        }
    }
