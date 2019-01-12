using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TopicRepository : IRepository<Topic>
    {
        private ForumContext db;

        public TopicRepository(ForumContext context)
        {
            this.db = context;
        }
        
        public IEnumerable<Topic> GetAll()
        {
            return db.Topics.ToList();
        }

        public IEnumerable<Topic> GetByTopicId(string topicId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetRepies(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetByUser(string userId)
        {
            return db.Topics.Where(x => x.UserId != null & x.UserId == userId);
        }

        public Topic Get(string  id)
        {
            return db.Topics.Find(id);
        }

        public IEnumerable<Topic> Find(Func<Topic, bool> predicate)
        {
            return db.Topics.Where(predicate).ToList();
        }

        public void Create(Topic newTopic)
        {
            db.Topics.Add(newTopic);
        }

        public void Update(Topic newTopic)
        {
            db.Entry(newTopic).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Topic topic = db.Topics.Find(id);
            if (topic != null)
            {
                db.Topics.Remove(topic);
            }
        }
    }
}