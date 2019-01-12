using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class Message
    {
        [Key]
        public string Id { get; set; }
        
        [ForeignKey("UserId")]        
        public string UserId { get; set; } 

        [ForeignKey("TopicId")] 
        public string TopicId { get; set; }

        public string ReplyToId { get; set; } 

        [Required]
        public DateTime Created { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }      

        public virtual ApplicationUser User { get; set; }
        
        public virtual Message ReplyTo { get; set; }
        
        public virtual Topic Topic { get; set; }

        public virtual ICollection<Message> Replies { get; set; }
    }
}