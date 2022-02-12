using System.Collections.Generic;

namespace UserManager.Services.Models
{
    public class PaginationUserModel
    {
        public List<UserModel> UserModels { get; set; }
        public int CountOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
