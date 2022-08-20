using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Common.ViewModels
    {
    public class UserVM
        {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [Remote("IsAlreadySignedUpStudent", "Login", ErrorMessage = "Email Already Exist", HttpMethod = "POST")]

        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; } = 3;
        }
    }
