using System;
using System.Linq;
using UserManager.Repositories.Interfaces;
using UserManager.Services.Mappers;
using UserManager.Services.Models;

namespace UserManager.Services.Services
{
    public class MessagesService
    {
        private readonly IMessagesRepository _messagesRepository;
        private const int DefaultMessageCount = 5;
        private const int DefaultCurrentPage = 1;

        public MessagesService(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public void CreateMessage(SendMessageModel model)
        {
            var item = MessagesMapper.Map(model);

            _messagesRepository.Create(item);
        }

        public PaginationMessageModel GetMessagesForRecipient(int recipientId, int currentPage)
        {

            if (currentPage == 0)
            {
                currentPage = DefaultCurrentPage;
            }

            var skip = (currentPage - 1) * DefaultMessageCount;
            var take = DefaultMessageCount;

            var items = _messagesRepository.GetByRecipientId(recipientId, skip, take);

            var modelsList = items.Select(x => MessagesMapper.Map(x)).ToList();

            var elementsCount = _messagesRepository.GetCountForRecipient(recipientId);

            var countOfPages = Convert.ToInt32(Math.Ceiling((double)elementsCount / take));

            var result = MessagesMapper.Map(modelsList, countOfPages, currentPage);

            return result;
        }

        public PaginationMessageModel GetMessagesForSender(int senderId, int currentPage)
        {

            if (currentPage == 0)
            {
                currentPage = DefaultCurrentPage;
            }

            var skip = (currentPage - 1) * DefaultMessageCount;
            var take = DefaultMessageCount;

            var items = _messagesRepository.GetByRecipientId(senderId, skip, take);

            var modelsList = items.Select(x => MessagesMapper.Map(x)).ToList();

            var elementsCount = _messagesRepository.GetCountForRecipient(senderId);

            var countOfPages = Convert.ToInt32(Math.Ceiling((double)elementsCount / take));

            var result = MessagesMapper.Map(modelsList, countOfPages, currentPage);

            return result;
        }
    }
}
