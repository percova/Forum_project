namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApi.Models.ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new ApplicationUserDTO() { Id = "1", UserName = "Percova" },
                new ApplicationUser() { Id = "2", UserName = "Faol" }
            );

            context.Topics.AddOrUpdate(x => x.Id,
                new TopicDTO() { Id = "1", Title = "A Little While", UserId = "1", Description = "Broken by the love. This hurt divides itself" },
                new Topic() { Id = "2", Title = "Time Adventure", UserId = "2", Description = "Time is an illusion that helps things make sense" }
            );

            context.Messeges.AddOrUpdate(x => x.Id,
                new MessageDTO() { Id = "1", TopicId = "1", UserId = "2", Text = "Decided that kissing you is just bad for my health" });

        }
    }
}
