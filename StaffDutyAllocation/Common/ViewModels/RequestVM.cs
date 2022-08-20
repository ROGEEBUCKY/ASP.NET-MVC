using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
    {
    public class RequestVM
        {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Dutyname { get; set; }
        public int DutyId { get; set; }
        public string Status { get; set; } = "pending";
        public string Readstatus { get; set; } = "unread";

        }
    }
