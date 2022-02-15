using System.Collections.Generic;
using System.Linq;
using UserManager.Repositories.Interfaces;
using UserManager.Repositories.Items;

namespace UserManager.Repositories.Repositories
{
    public class MessagesRepository : BaseRepository<MessageItem>, IMessagesRepository
    {
        public MessagesRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<MessageItem> GetByRecipientId(int recipientId, int skip, int take)
        {
            return GetItems()
                .Where(x => x.RecipientId == recipientId)
                .OrderBy(x => x.Date)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

    }
}
