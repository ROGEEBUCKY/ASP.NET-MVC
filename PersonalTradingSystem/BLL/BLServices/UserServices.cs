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
        readonly UserRepository Dobj;
        public UserServices()
            {
            Dobj = new UserRepository();
            }

        public void AddUser(UserVM regUser)
            {
            var user = Mapper.Map<UserVM, User>(regUser);
            Dobj.AddUser(user);
            }

        public List<UserVM> GetUsers()
            {
            var list = Dobj.GetAllUser().Where(u => u.RoleId == 3).ToList();
            return Mapper.Map<List<User>, List<UserVM>>(list);
            }
        public UserVM GetUserById(int id)
            {
            var user = Dobj.GetUserById(id);
            return Mapper.Map<User, UserVM>(user);  
            }
        }
    }
