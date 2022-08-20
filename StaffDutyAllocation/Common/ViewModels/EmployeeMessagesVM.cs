using System;

namespace Common.ViewModels
    {
    public class EmployeeMessagesVM
        {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public string MessageType { get; set; }
        public DateTime MessageCreatedTime { get; set; }

        }
    }
