using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;

namespace BLL.Services
{
    class TopicService : ITopicService
    {
        IUnitOfWork Database { get; set; }
        IMapper mapper;

        public TopicService(IUnitOfWork database, IMapper mapper)
        {
            Database = database;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<Topic, TopicDTO>()).CreateMapper(); 
        }

        public List<TopicDTO> GetByUserId(string userId)
        {
            return mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(Database.Topics.GetByUser(userId));
        }

        public void Add(TopicDTO newTopic)
        {
            if (newTopic.Title == null)
            {
                throw new ArgumentNullException(nameof(newTopic.Title));
            }
            
            newTopic.Id = Guid.NewGuid().ToString();
            newTopic.CreationDate = DateTime.Now;
            
            Database.Topics.Create(mapper.Map<TopicDTO, Topic>(newTopic));
        }

        public void Delete(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Database.Topics.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Edit(TopicDTO topic)
        {
            if (topic.Id == null)
            {
                throw new ArgumentNullException(nameof(topic.Id));
            }
            var _topic = mapper.Map<TopicDTO, Topic>(topic);
            Database.Topics.Update(_topic);
        }

        public List<TopicDTO> GetAll()
        { 
            return mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(Database.Topics.GetAll());
        }
    
        public TopicDTO GetById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id)); 
            }
            var topic = Database.Topics.Get(id);
            if (topic == null)
            {
                throw new ArgumentNullException("Cannot found topic with such ID");
            }
            return mapper.Map<Topic, TopicDTO>(topic);
        }
    }
}
