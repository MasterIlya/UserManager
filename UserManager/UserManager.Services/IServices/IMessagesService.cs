using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManager.Services.Models;

namespace UserManager.Services.IServices
{
    public interface IMessagesService
    {
        public Task CreateMessageAsync(SendMessageModel model);
        public PaginationMessageModel<InboxMessageModel> GetInbox(int recipientId, int currentPage);
        public PaginationMessageModel<SentMessageModel> GetSent(int senderId, int currentPage);
        public void UpdateMessageState(int messageId);
    }
}
