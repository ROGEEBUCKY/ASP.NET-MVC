using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
    {
    public class User
        {


        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Age")]
        [Range(20, 45, ErrorMessage = "Age Should be min 20 and max 45")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please Provide Gender")]
        public string Gender { get; set; }
        }
    }