using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
    {
    public class Message
        {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Type { get; set; }
        public  User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        }
    }
