using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class WishlistItem
    {
        [Key]
        public int WishlistItemId { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        [ForeignKey("User")]
        public string UserId { get; set; } // Link to ApplicationUser.Id
        public AppUser User { get; set; }

        // Foreign Key (Nullable to allow wishlist for both Notices and Events)
        public int? NoticeId { get; set; }
        public Notice? Notice { get; set; }

        public int? EventId { get; set; }
        public Event? Event { get; set; }

        [MaxLength(100)]
        public string? EventCategory { get; set; } // Store category for watchlist filtering
    }
}