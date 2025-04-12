using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EventRating
    {
        [Key]
        public int EventRatingId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public DateTime RatingDate { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        [ForeignKey("User")]
        public string UserId { get; set; } // link to appuser id
        public AppUser User { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}