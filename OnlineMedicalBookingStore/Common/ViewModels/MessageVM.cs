using System;
using System.ComponentModel.DataAnnotations;

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
        }
    }
