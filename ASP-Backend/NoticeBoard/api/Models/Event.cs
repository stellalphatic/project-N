using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public string? ImageUrl { get; set; } // URL from Cloudinary
        public bool IsFeatured { get; set; }

        // Foreign Key
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public AppUser Author { get; set; }

        // Navigation Properties
        public ICollection<EventRating> Ratings { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
        public ICollection<EventCategory> EventCategories { get; set; } // Many-to-many
        public ICollection<Comment> Comments { get; set; }
    }
}