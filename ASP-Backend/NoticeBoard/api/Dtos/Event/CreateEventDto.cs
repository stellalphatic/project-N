using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Event
{
    public class CreateEventDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        // AuthorId will be obtained from the authenticated user
    }
}