using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankManagementSystem.Models
    {
    public class User
        {
        [Required(ErrorMessage = "This field is Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [EmailAddress(ErrorMessage ="Invalid Format")]
        public string Email { get; set; }
        }
    }