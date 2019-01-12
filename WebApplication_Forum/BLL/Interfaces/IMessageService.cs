using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IMessageService : IDisposable
    {
        List<MessageDTO> GetByTopicId(string id);
        List<MessageDTO> GetReplies(string id);
        List<MessageDTO> GetByUser(string userId);
        void Add(MessageDTO newMessage);
        void Edit(MessageDTO message);
        void Delete(string id);

        void Dispose();
    }
}
