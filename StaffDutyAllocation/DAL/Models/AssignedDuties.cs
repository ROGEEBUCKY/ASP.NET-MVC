using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
    {
    public class AssignedDuties
        {
        public int Id { get; set; } 
        public Duty Duty { get; set; }
        [ForeignKey("Duty")]
        public int DutyId { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public Roster Roster { get; set; }
        [ForeignKey("Roster")]
        public int RosterId { get; set; }   
        public string DutyType { get; set; }
        public DateTime AssignedTime { get; set; }
        }
    }
