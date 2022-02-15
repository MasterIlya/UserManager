using System;
using System.Collections.Generic;
using UserManager.Repositories.Items;
using UserManager.Services.Models;

namespace UserManager.Services.Mappers
{
    public class MessagesMapper
    {
        public static MessageItem Map(SendMessageModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new MessageItem
            {
                SenderId = model.SenderId,
                RecipientId = model.RecipientId,
                Date = DateTime.Now,
                MessageText = model.MessageText,
                MessageTopic = model.MessageTopic,
                Readed = false
            };
        }

        public static MessageModel Map(MessageItem item)
        {
            if (item == null)
            {
                return null;
            }

            return new MessageModel
            {
                MessageId = item.MessageId,
                SenderId = item.SenderId,
                RecipientId = item.RecipientId,
                Date = item.Date,
                MessageTopic = item.MessageTopic,
                MessageText = item.MessageText,
                Readed = item.Readed
            };
        }

        public static PaginationMessageModel Map(List<MessageModel> generalMessageModels, int countOfPages, int currentPage)
        {
            return new PaginationMessageModel
            {
                MessageModels = generalMessageModels,
                CountOfPages = countOfPages,
                CurrentPage = currentPage
            };
        }
    }
}
