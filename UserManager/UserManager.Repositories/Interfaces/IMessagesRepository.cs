using System.Collections.Generic;
using UserManager.Repositories.Items;

namespace UserManager.Repositories.Interfaces
{
    public interface IMessagesRepository
    {
        void Create(MessageItem item);
        MessageItem Get(int MessageId);
        public List<MessageItem> GetByRecipientId(int recipientId, int skip, int take);
        public List<MessageItem> GetBySenderId(int senderId, int skip, int take);
        public int GetCountForRecipient(int recipientId);
        public int GetCountForSender(int senderId);
    }
}
