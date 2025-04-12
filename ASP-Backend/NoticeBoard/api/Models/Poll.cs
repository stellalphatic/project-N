using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Poll
    {
        [Key]
        public int PollId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Question { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        // Foreign Key
        [ForeignKey("Author")]
        public string AuthorId { get; set; } 
        public AppUser Author { get; set; }

        // Navigation Properties
        public ICollection<PollOption> Options { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}