using System.ComponentModel.DataAnnotations;

namespace UserManager.Services.Models
{
    public class RegistrationUserModel
    {
        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The length of the email address must be from 8 to 50 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password not specified")]
        [Compare("PasswordConfirm", ErrorMessage = "Passwords don't match")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password not specified")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "User name not specified")]
        public string Name { get; set; }
    }
}
