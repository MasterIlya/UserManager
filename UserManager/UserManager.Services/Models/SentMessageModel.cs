using System;

namespace UserManager.Services.Models
{
    public class SentMessageModel
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public string RecipinetEmail { get; set; }
        public DateTime Date { get; set; }
        public string MessageTopic { get; set; }
        public string MessageText { get; set; }
        public bool Readed { get; set; }
    }
}
