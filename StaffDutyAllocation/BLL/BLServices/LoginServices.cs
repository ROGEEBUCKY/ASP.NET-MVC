using AutoMapper;
using Common.ViewModels;
using DAL.Models;
using DAL.Repository;
using System.Linq;

namespace BLL.BLServices
    {
    public class LoginServices
        {
        readonly UserRepository userDObj;
        public LoginServices()
            {
            userDObj = new UserRepository();
            }

        public UserVM LoginUserB(LoginVM logUser)
            {
            User user = userDObj.GetAllUsersD().FirstOrDefault(u => u.LoginId == logUser.LoginId && u.LoginPass == logUser.LoginPass && u.IsBlocked != "true");
            return Mapper.Map<User, UserVM>(user);
            }
        public RoleVM GetUserRoleB(int id)
            {
            var role = userDObj.GetUserRoleD(id);
            return Mapper.Map<Role, RoleVM>(role);
            }
        }
    }
