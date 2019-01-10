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

        public Message Get(int id)
        {
            return db.Messeges.Find(id);
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

        public void Delete(int id)
        {
            Message message = db.Messeges.Find(id);
            if (message != null)
            {
                db.Messeges.Remove(message);
            }
        }
    }
}