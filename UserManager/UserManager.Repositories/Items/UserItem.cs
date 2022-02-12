using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManager.Commons.Enums;

namespace UserManager.Repositories.Items
{
    [Table("Users")]
    public class UserItem
    {
        [Key]
        public virtual int UserId { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime RegistrationDate { get; set; }
        public virtual DateTime LoginDate { get; set; }
        public virtual StateTypes State { get; set; }
        public virtual bool Delisted { get; set; }
    }
}
