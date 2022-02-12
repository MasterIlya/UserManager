using System;
using UserManager.Commons.Enums;

namespace UserManager.Services.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LoginDate { get; set; }
        public StateTypes State { get; set; }
        public bool Delisted { get; set; }
    }
}
