using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels
    {
    public class LoginVM
        {
        [Required]
        [RegularExpression(@"^[A-Za-z0-9._]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Invalid Email format.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        }
    }
