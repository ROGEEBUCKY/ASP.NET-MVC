using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
    {
    public class Request
        {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Duty Duty { get; set; }
        [ForeignKey("Duty")]
        public int DutyId { get; set; }
        public string Status { get; set; }
        public string Readstatus { get; set; } = "unread";
        }
    }
