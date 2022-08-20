using Common.ViewModels;
using DAL.Models;
using DAL.Repository;
using System.Linq;
using AutoMapper;

namespace BLL.BLServices
    {
    public class LoginServices
        {
        readonly UserRepository UDObj;
        public LoginServices()
            {
            UDObj = new UserRepository();
            }

        public UserVM Login(LoginVM logUser)
            {
            User user = UDObj.GetAllUser()
                .Where(u => u.Email.ToLower() == logUser.Email.ToLower() && u.Password == logUser.Password)
                .FirstOrDefault();
                return Mapper.Map<User, UserVM>(user);
            }

        public bool CheckUser(string mail)
            {
            return UDObj.GetAllUser().Any(u => u.Email.ToLower() == mail.ToLower());    
            }
        }
    }
