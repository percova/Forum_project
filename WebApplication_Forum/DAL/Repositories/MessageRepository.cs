using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private ForumContext db;

        public MessageRepository(ForumContext context)
        {
            this.db = context;
        }
        
        public IEnumerable<Message> GetAll()
        {
            return db.Messeges.Include( m => m.Topic);
        }

        public IEnumerable<Message> GetRepies(string id)
        {
            return db.Messeges.Where( x => x.ReplyToId != null & x.ReplyToId == id ).ToList();
        }

        public IEnumerable<Message> GetByUser(string userId)
        {
            return db.Messeges.Where(x => x.UserId != null & x.UserId == userId);
        }

        public Message Get(string id)
        {
            return db.Messeges.Find(id);
        }

        public IEnumerable<Message> GetByTopicId(string topicId)
        {
            return db.Messeges.Include(x => x.User).Include(x => x.Topic).Where(x => x.Topic.Id == topicId);
        }


        public IEnumerable<Message> Find(Func<Message, bool> predicate)
        {
            return db.Messeges.Include( m => m.Topic).Where(predicate).ToList();
        }

        public void Create(Message newMessage)
        {
            db.Messeges.Add(newMessage);
        }

        public void Update(Message newMessage)
        {
            db.Entry(newMessage).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Message message = db.Messeges.Find(id);
            if (message != null)
            {
                db.Messeges.Remove(message);
            }
        }
    }
}