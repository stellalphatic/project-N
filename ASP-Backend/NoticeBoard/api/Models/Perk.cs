using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class PerkAssignment
    {
        [Key]
        public int PerkAssignmentId { get; set; }
        public int Perks { get; set; }
        public string? Reason { get; set; }
        public DateTime AssignmentDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}