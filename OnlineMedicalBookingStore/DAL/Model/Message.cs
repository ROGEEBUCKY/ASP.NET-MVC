using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
    {
    public class Message
        {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Type { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        }
    }
