using AutoMapper;
using Common.ViewModels;
using DAL.Model;
using DAL.Repository;
using System.Linq;

namespace BLL.BLServices
    {
    public class LoginServices
        {
        readonly UserRepository _userDObj;
        public LoginServices()
            {
            _userDObj = new UserRepository();
            }

        public UserVM LoginUser(LoginVM logonUser)
            {
            var user = _userDObj.GetAllUsersForLogin().Where(u => u.Email.ToLower() == logonUser.Email.ToLower() && u.Password == logonUser.Password).FirstOrDefault();
            return Mapper.Map<User, UserVM>(user);
            }
        public RoleVM GetUserRole(int id)
            {
            var role = _userDObj.GetUserRole(id);
            return Mapper.Map<Role, RoleVM>(role);
            }
        public UserVM CheckMail(string mail)
            {
            User user = _userDObj.CheckMail(mail);
            return Mapper.Map<User, UserVM>(user);
            }

        public void Register(UserVM newUser)
            {
            var user = Mapper.Map<UserVM, User>(newUser);
            _userDObj.AddUpdateUser(user);
            }
        }
    }
