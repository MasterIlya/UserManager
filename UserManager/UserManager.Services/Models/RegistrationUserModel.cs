using System.ComponentModel.DataAnnotations;

namespace UserManager.Services.Models
{
    public class RegistrationUserModel
    {
        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress(ErrorMessage = "Неккоректный электронный адрес")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Длинна электронного адреса должна быть от 8 до 50 символов")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [Compare("PasswordConfirm", ErrorMessage = "Пароли не совпадают")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Не указано поддтверждение пароля")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Name { get; set; }
    }
}
