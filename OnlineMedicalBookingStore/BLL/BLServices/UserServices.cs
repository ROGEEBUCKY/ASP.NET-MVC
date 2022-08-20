using AutoMapper;
using Common.ViewModels;
using DAL.Model;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BLServices
    {
    public class UserServices
        {
        readonly UserRepository _userDObj;
        public UserServices()
            {
            _userDObj = new UserRepository();
            }

        public List<UserVM> GetAllUsers()
            {
            var userList = _userDObj.GetAllCustomers();
            return Mapper.Map<List<User>, List<UserVM>>(userList);
            }



        public void DeleteUser(int id)
            {
            _userDObj.DeleteUserById(id);
            }

        public List<UserVM> GetAllMessagedUser()
            {
            var messagedList = _userDObj.GetAllMessagedUsers();
            var messagedUserList = messagedList.Select(m => m.User).Where(u => u.IsBlocked == false).ToList();
            return Mapper.Map<List<User>, List<UserVM>>(messagedUserList);
            }

        public List<MessageVM> GetUserMessagesById(int id)
            {
            var userMessages = _userDObj.GetUserMessagesById(id);
            return Mapper.Map<List<Message>, List<MessageVM>>(userMessages);
            }

        public void SendNewMessage(MessageVM newMessage)
            {
            var msg = Mapper.Map<MessageVM, Message>(newMessage);
            _userDObj.AddNewMessage(msg);
            }

        public void EditUser(UserVM user)
            {
            var DUser = Mapper.Map<UserVM, User>(user);
            _userDObj.AddUpdateUser(DUser);
            }

        public UserVM GetUserById(int id)
            {
            var dUser = _userDObj.GetUserByID(id);
            return Mapper.Map<User, UserVM>(dUser);
            }
        }
    }
