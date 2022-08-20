using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DAL.Models
    {
    public class User
        {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Role Role { get; set; } 
        [ForeignKey("Role")]
        public int RoleId { get; set; } = 3;
        }
    }
