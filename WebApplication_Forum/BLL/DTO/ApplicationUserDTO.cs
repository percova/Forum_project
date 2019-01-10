using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    class ApplicationUserDTO : IdentityUser
    {
        public virtual ICollection<Message> MyMessages { get; set; } = new List<Message>();

        public virtual ICollection<Topic> MyTopics { get; set; } = new List<Topic>();
    }
}
