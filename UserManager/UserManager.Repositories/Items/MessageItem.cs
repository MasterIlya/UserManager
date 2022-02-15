using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager.Repositories.Items
{
    [Table("Messages")]
    public class MessageItem
    {
        [Key]
        public virtual int MessageId { get; set; }
        public virtual int SenderId { get; set; }
        public virtual int RecipientId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string MessageTopic { get; set; }
        public virtual string MessageText { get; set; }
        public virtual bool Readed { get; set; }

    }
}
