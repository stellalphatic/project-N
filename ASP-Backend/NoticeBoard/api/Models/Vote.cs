using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        [ForeignKey("User")]
        public string UserId { get; set; } //actually appuser.id
        public AppUser User { get; set; }

        [ForeignKey("PollOption")]
        public int PollOptionId { get; set; }
        public PollOption PollOption { get; set; }
    }
}