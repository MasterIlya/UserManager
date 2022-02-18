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
                .OrderByDescending(x => x.CreatedDate)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<MessageItem> GetBySenderId(int senderId, int skip, int take)
        {
            return GetItems()
                .Where(x => x.SenderId == senderId)
                .OrderByDescending(x => x.CreatedDate)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public int GetCountForRecipient(int recipientId)
        {
            return GetItems().Where(x => x.RecipientId == recipientId).Count();
        }

        public int GetCountForSender(int senderId)
        {
            return GetItems().Where(x => x.SenderId == senderId).Count();
        }
    }
}
