using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    class MessageService : IMessageService
    {
        IUnitOfWork Database { get; set; }
        IMapper mapper;

        public MessageService(IUnitOfWork database, IMapper mapper)
        {
            Database = database;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<Topic, TopicDTO>()).CreateMapper();
        }

        public void Add(MessageDTO newMessage)
        {
            if (newMessage.TopicId == null)
            {
                throw new ArgumentNullException(nameof(newMessage.TopicId));
            }

            newMessage.Id = Guid.NewGuid().ToString();
            newMessage.Time = DateTime.Now;

            Database.Messages.Create(mapper.Map<MessageDTO, Message>(newMessage));
        }

        public void Edit(MessageDTO message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            
            Database.Messages.Update(mapper.Map<MessageDTO, Message>(message));
        }

        public void Delete(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            
            Database.Messages.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public List<MessageDTO> GetReplies(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            
            return mapper.Map<IEnumerable<Message>, List<MessageDTO>>(Database.Messages.GetRepies(id));
        }

        public List<MessageDTO> GetByTopicId(string topicId)
        {
            if (topicId == null)
            {
                throw new ArgumentNullException(nameof(topicId));
            }

            return mapper.Map<IEnumerable<Message>, List<MessageDTO>>(Database.Messages.GetByTopicId(topicId));
        }
        
        public List<MessageDTO> GetByUser(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return mapper.Map<IEnumerable<Message>, List<MessageDTO>>(Database.Messages.GetByUser(userId));
        }
    }
}

