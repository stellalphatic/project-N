using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
       public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        [ForeignKey("User")]
        public string UserId { get; set; } //link to appuser id
        public AppUser User { get; set; }

        // Foreign Key (Nullable for comments on different entities)
        public int? NoticeId { get; set; }
        public Notice? Notice { get; set; }

        public int? EventId { get; set; }
        public Event? Event { get; set; }
    }
}