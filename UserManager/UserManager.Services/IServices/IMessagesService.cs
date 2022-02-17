using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Services.Models;

namespace UserManager.Services.IServices
{
    public interface IMessagesService
    {
        public void CreateMessage(SendMessageModel model);
        public PaginationMessageModel<InboxMessageModel> GetInbox(int recipientId, int currentPage);
        public PaginationMessageModel<SentMessageModel> GetSent(int senderId, int currentPage);
        public void UpdateMessageState(int messageId);
    }
}
