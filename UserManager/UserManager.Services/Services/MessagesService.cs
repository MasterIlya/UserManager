using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Repositories.Interfaces;
using UserManager.Services.Hubs;
using UserManager.Services.IServices;
using UserManager.Services.Mappers;
using UserManager.Services.Models;

namespace UserManager.Services.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IMessagesRepository _messagesRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IHubConnectionService _hubConnectionService;
        private const int DefaultMessageCount = 5;
        private const int DefaultCurrentPage = 1;

        public MessagesService(IMessagesRepository messagesRepository, IUsersRepository usersRepository,
            IHubContext<NotificationHub> hubContext, IHubConnectionService hubConnectionService)
        {
            _usersRepository = usersRepository;
            _messagesRepository = messagesRepository;
            _hubContext = hubContext;
            _hubConnectionService = hubConnectionService;
        }

        public async Task CreateMessageAsync(SendMessageModel model)
        {
            var recipientId = _usersRepository.GetByEmail(model.RecipientEmail).UserId;
            var senderId = _usersRepository.GetByEmail(model.SenderEmail).UserId;
            var connectionId = _hubConnectionService.GetFromCache(recipientId);
            
            var item = MessagesMapper.Map(model, senderId, recipientId);

            _messagesRepository.Create(item);

            await _hubContext.Clients.Client(connectionId).SendAsync("Notify", recipientId.ToString());
        }

        public PaginationMessageModel<InboxMessageModel> GetInbox(int recipientId, int currentPage)
        {
            if (currentPage == 0)
            {
                currentPage = DefaultCurrentPage;
            }

            var skip = (currentPage - 1) * DefaultMessageCount;
            var take = DefaultMessageCount;

            var items = _messagesRepository.GetByRecipientId(recipientId, skip, take);

            var modelsList = items.Select(x => MessagesMapper.MapForReceivedMessage(x, _usersRepository.Get(x.SenderId).Email)).ToList();

            var elementsCount = _messagesRepository.GetCountForRecipient(recipientId);

            var countOfPages = Convert.ToInt32(Math.Ceiling((double)elementsCount / take));

            var result = MessagesMapper.Map(modelsList, countOfPages, currentPage);

            return result;
        }

        public PaginationMessageModel<SentMessageModel> GetSent(int senderId, int currentPage)
        {
            if (currentPage == 0)
            {
                currentPage = DefaultCurrentPage;
            }

            var skip = (currentPage - 1) * DefaultMessageCount;
            var take = DefaultMessageCount;

            var items = _messagesRepository.GetBySenderId(senderId, skip, take);

            var modelsList = items.Select(x => MessagesMapper.MapForSentMessage(x, _usersRepository.Get(x.RecipientId).Email)).ToList();

            var elementsCount = _messagesRepository.GetCountForSender(senderId);

            var countOfPages = Convert.ToInt32(Math.Ceiling((double)elementsCount / take));

            var result = MessagesMapper.Map(modelsList, countOfPages, currentPage);

            return result;
        }

        public void UpdateMessageState(int messageId)
        {
            var item = _messagesRepository.Get(messageId);
            item.Readed = true;
            _messagesRepository.Update(item);
        }
    }
}
