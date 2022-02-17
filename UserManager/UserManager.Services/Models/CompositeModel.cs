using System.Collections.Generic;

namespace UserManager.Services.Models
{
    public class CompositeModel
    {
        public List<UserModel> users { get; set; }
        public SendMessageModel messageModel { get; set; }
    }
}
