using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class Topic
    {
        [Key]
        public string Id { get; set; }
        
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        
        [Required]
        public DateTime CreationDate { get; set; }
        
        [Required]
        [MaxLength(50)]
        public  string Title { get; set; }
            
        [MaxLength(500)]
        public string Description { get; set; }
                
        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Message> Messeges { get; set; } = new List<Message>();
    }
}