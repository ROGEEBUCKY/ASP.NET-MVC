using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
    {
    public class User
        {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public float? BasicSalary { get; set; }
        public string LoginId { get; set; }
        public string LoginPass { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IsBlocked { get; set; }
        public virtual Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public DateTime LastLoginTime { get; set; }

        }
    }
