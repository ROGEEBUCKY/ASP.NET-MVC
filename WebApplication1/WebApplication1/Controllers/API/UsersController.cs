using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
    {
    public class UsersController : ApiController
        {
        private ProjectContext _context;
        public UsersController()
            {
            _context = new ProjectContext();
            }


        // Get /api/users
        public IEnumerable<UserDto> GetUsers()
            {
            return _context.Users.ToList().Select(Mapper.Map<User, UserDto>);
            }

        // GET /api/users/1
        public UserDto GetUser(int id) 
            {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<User, UserDto>(user);
            }

        //POST /api/users
        [HttpPost]
        public UserDto CreateUser(UserDto userDto)
            {
            var users = Mapper.Map<UserDto, User>(userDto);
            if (ModelState.IsValid)
                {
                _context.Users.Add(users);
                }
            else
                {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

            _context.SaveChanges();
            userDto.Id = users.Id;
            return userDto;
            }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateUser(int id, UserDto userDto)
            {
            if (!ModelState.IsValid)
                {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

            var userinfo = _context.Users.SingleOrDefault(x => x.Id == id);

            if (userinfo == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(userDto, userinfo);
       

            _context.SaveChanges();
            }



        // DELETE /api/Users/1
        [HttpDelete]
        public void DeleteCustomer(int id)
            {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);


            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Users.Remove(user);
            _context.SaveChanges();
            }

        }
    }
