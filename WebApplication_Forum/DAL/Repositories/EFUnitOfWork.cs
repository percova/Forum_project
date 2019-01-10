using System;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ForumContext db;
        private UserRepository _userRepository;
        private TopicRepository _topicRepository;
        private MessageRepository _messageRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ForumContext(connectionString);
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(db);
                }

                return _userRepository;
            }
        }
        
        public IRepository<Topic> Topics
        {
            get
            {
                if (_topicRepository == null)
                {
                    _topicRepository = new TopicRepository(db);
                }

                return _topicRepository;
            }
        }
        
        public IRepository<Message> Messages
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(db);
                }

                return _messageRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}