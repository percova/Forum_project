using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Topic> Topics { get; }
        IRepository<Message> Messages { get; }
        void Save();
    }
}