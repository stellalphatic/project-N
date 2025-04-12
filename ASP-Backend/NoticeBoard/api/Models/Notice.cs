using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime PostDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPinned { get; set; }

        // Foreign Key
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public AppUser Author { get; set; }

        // Navigation Properties
        public ICollection<Comment> Comments { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}