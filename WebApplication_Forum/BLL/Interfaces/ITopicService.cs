using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface ITopicService : IDisposable
    {
        TopicDTO GetById(string id);
        List<TopicDTO> GetAll();
        List<TopicDTO> GetByUserId(string userId);
        void Add(TopicDTO newTopic);
        void Edit(TopicDTO topic);
        void Delete(string id);

        void Dispose();
    }
}
