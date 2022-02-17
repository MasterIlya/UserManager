using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Services.Models
{
    public class InboxMessageModel
    {
        public int MessageId { get; set; }
        public string SenderEmail { get; set; }
        public int RecipinetId { get; set; }
        public DateTime Date { get; set; }
        public string MessageTopic { get; set; }
        public string MessageText { get; set; }
        public bool Readed { get; set; }
    }
}
