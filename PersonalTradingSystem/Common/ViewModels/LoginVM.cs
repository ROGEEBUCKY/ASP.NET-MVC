using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
    {
    public class LoginVM
        {
        [EmailAddress(ErrorMessage="Please input valid Email")]
        [Required(ErrorMessage ="Please fill your Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please fill your password")]
        public string Password { get; set; }
        }
    }
