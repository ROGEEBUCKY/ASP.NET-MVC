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
        [Required]
        [Display(Name ="User Id")]
        public string LoginId { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string LoginPass { get; set; }
        }
    }
