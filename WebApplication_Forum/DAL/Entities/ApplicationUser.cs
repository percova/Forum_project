using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public DateTime JoinDate { get; set; }
        
        public virtual ICollection<Message> MyMessages { get; set; } = new List<Message>();
        
        public virtual ICollection<Topic> MyTopics { get; set; } = new List<Topic>();
        
    }
}