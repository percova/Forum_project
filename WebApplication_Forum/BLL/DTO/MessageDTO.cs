using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    class MessageDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string TopicId { get; set; }
        public DateTime? Time { get; set; }
        //public string ReplyToId { get; set; }
        public string Text { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual Message Replied { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
