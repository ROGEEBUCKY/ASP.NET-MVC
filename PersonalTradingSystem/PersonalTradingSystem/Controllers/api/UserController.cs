using BLL.BLServices;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalTradingSystem.Controllers.api.userapi
{
    public class UserController : ApiController
    {
        readonly UserServices UBLO;
        public UserController()
            {
            UBLO = new UserServices();
            }
        public IEnumerable<UserVM> GetUsers()
            {
            var list = UBLO.GetUsers();
            return list;
            }
        public UserVM GetUserById(int id)
            {
            var user = UBLO.GetUserById(id);
            return user;
            }
    }
}
