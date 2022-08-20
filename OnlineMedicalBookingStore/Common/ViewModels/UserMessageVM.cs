using System;

namespace Common.ViewModels
    {
    public class UserMessageVM
        {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime LastMessageCreatedTime { get; set; }
        }
    }
