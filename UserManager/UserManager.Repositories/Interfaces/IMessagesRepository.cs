using System.Collections.Generic;
using UserManager.Repositories.Items;

namespace UserManager.Repositories.Interfaces
{
    interface IMessagesRepository
    {
        void Create(MessageItem item);

        MessageItem Get(int MessageId);
        public List<MessageItem> GetByRecipientId(int recipientId, int skip, int take);
    }
}
