using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    class TopicDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Message> Messeges { get; set; } = new List<Message>();
    }
}
