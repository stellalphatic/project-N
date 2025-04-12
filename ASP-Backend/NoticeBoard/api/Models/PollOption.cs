using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class PollOption
    {
        [Key]
        public int PollOptionId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }

        // Foreign Key
        [ForeignKey("Poll")]
        public int PollId { get; set; }
        public Poll Poll { get; set; }

        // Navigation Property
        public ICollection<Vote> Votes { get; set; }
    }
}