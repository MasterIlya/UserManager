using System;
using System.Collections.Generic;
using UserManager.Repositories.Items;
using UserManager.Services.Models;

namespace UserManager.Services.Mappers
{
    public class MessagesMapper
    {
        public static MessageItem Map(SendMessageModel model, int senderId, int recipientId)
        {
            if (model == null)
            {
                return null;
            }

            return new MessageItem
            {
                SenderId = senderId,
                RecipientId = recipientId,
                CreatedDate = DateTime.Now,
                MessageText = model.MessageText,
                MessageTopic = model.MessageTopic,
                Readed = false
            };
        }

        public static SentMessageModel MapForSentMessage(MessageItem item, string recipientEmail)
        {
            if (item == null)
            {
                return null;
            }

            return new SentMessageModel
            {
                MessageId = item.MessageId,
                SenderId = item.SenderId,
                RecipinetEmail = recipientEmail,
                Date = item.CreatedDate,
                MessageTopic = item.MessageTopic,
                MessageText = item.MessageText,
                Readed = item.Readed
            };
        }

        public static InboxMessageModel MapForReceivedMessage(MessageItem item, string senderEmail)
        {
            if (item == null)
            {
                return null;
            }

            return new InboxMessageModel
            {
                MessageId = item.MessageId,
                SenderEmail = senderEmail,
                RecipinetId = item.RecipientId,
                Date = item.CreatedDate,
                MessageTopic = item.MessageTopic,
                MessageText = item.MessageText,
                Readed = item.Readed
            };
        }

        public static PaginationMessageModel<SentMessageModel> Map(List<SentMessageModel> generalMessageModels, int countOfPages, int currentPage)
        {
            return new PaginationMessageModel<SentMessageModel>
            {
                MessageModels = generalMessageModels,
                CountOfPages = countOfPages,
                CurrentPage = currentPage
            };
        }

        public static PaginationMessageModel<InboxMessageModel> Map(List<InboxMessageModel> generalMessageModels, int countOfPages, int currentPage)
        {
            return new PaginationMessageModel<InboxMessageModel>
            {
                MessageModels = generalMessageModels,
                CountOfPages = countOfPages,
                CurrentPage = currentPage
            };
        }
    }
}
