using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
    {
    public class MessageVM
        {
        public int Id { get; set; }
        [Required]
        public string MessageText { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public int UserId { get; set; }
        public int UserName { get; set; }
        public string Readstatus { get; set; } = "unread";

        }
    }
