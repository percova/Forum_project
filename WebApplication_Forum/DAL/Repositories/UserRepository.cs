using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<ApplicationUser>
    {
        private ForumContext db;

        public UserRepository(ForumContext context)
        {
            this.db = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return db.Users;
        }
        
        public ApplicationUser Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Create(ApplicationUser newUser)
        {
            db.Users.Add(newUser);
        }

        public void Update(ApplicationUser newUser)
        {
            db.Entry(newUser).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ApplicationUser user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }
    }
}