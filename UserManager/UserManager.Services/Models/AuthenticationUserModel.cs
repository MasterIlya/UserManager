using System.ComponentModel.DataAnnotations;

namespace UserManager.Services.Models
{
    public class AuthenticationUserModel
    {
        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password not specified")]
        public string Password { get; set; }
    }
}
