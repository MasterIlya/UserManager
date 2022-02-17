using System.Collections.Generic;

namespace UserManager.Services.Models
{
    public class PaginationMessageModel<T>
    {
        public List<T> MessageModels { get; set; }
        public int CountOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
