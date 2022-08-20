using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Common.ViewModels
    {
    public class UserVM
        {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z '.-]*[A-Za-z][^-]$", ErrorMessage = "Invalid Name format.")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9._]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Invalid Email format.")]
        [Remote("EmailAlreadyExist", "Login", ErrorMessage = "Email Already Exist", HttpMethod = "POST")]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{6}|[0-9]{3}\s[0 - 9]{ 3})$", ErrorMessage = "Invalid Zip Code.")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^(?:(?:\+|0{0,2})91(\s*|[\-])?|[0]?)?([6789]\d{2}([ -]?)\d{3}([ -]?)\d{4})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
        public bool IsBlocked { get; set; } = false;
        public int RoleId { get; set; } = 2;
        public List<OrderVM> UserOrders { get; set; } = new List<OrderVM>();
        }
    }
