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
            return db.Topics;
        }

        public Topic Get(int id)
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

        public void Delete(int id)
        {
            Topic topic = db.Topics.Find(id);
            if (topic != null)
            {
                db.Topics.Remove(topic);
            }
        }
    }
}