using System.Data.Entity;
using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ForumContext : DbContext
    {
        public ForumContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messeges { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}