using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Services.Models
{
    public class SendMessageModel
    {
        public virtual int SenderId { get; set; }
        public virtual int RecipientId { get; set; }
        public virtual string MessageTopic { get; set; }
        public virtual string MessageText { get; set; }
    }
}
