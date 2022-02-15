using System.Collections.Generic;

namespace UserManager.Services.Models
{
    public class PaginationMessageModel
    {
        public List<MessageModel> MessageModels { get; set; }
        public int CountOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
