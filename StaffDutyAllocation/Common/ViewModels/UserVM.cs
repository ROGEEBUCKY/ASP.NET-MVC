using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.ViewModels
    {
    public class UserVM
        {
        public int? Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9._]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Invalid Email format.")]
        [Remote("EmailAlreadyExist", "Admin", ErrorMessage = "Email Already Exist", HttpMethod = "POST")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^(?:(?:\+|0{0,2})91(\s*|[\-])?|[0]?)?([6789]\d{2}([ -]?)\d{3}([ -]?)\d{4})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNumber { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Basic pay")]
        [Range(10000,20000,ErrorMessage ="Basic salary must be between 10,000 to 20,000")]
        public float? BasicSalary { get; set; }
        [Display(Name ="Login ID")]
        [Required]
        [Remote("UserIdAlreadyExist", "Admin", ErrorMessage = "LoginId Already Exist", HttpMethod = "POST")]
        public string LoginId { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string LoginPass { get; set; }
        [Required]
        public string Gender { get; set; }
        [Display(Name ="DOB")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }
        public string IsBlocked { get; set; } = "false";
        public int RoleId { get; set; } = 3;
        public DateTime LastLoginTime { get; set; }
        }
    }
