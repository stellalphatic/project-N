using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EventCategory
    {
        [Key]
        public int EventCategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Event> Events { get; set; }
    }
}