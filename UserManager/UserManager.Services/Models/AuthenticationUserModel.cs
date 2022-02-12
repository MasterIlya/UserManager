using System.ComponentModel.DataAnnotations;

namespace UserManager.Services.Models
{
    public class AuthenticationUserModel
    {
        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress(ErrorMessage = "Неккоректный электронный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
