using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Society
    {
        [Key]
        public int SocietyId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<SocietyMembership> Memberships { get; set; }
        public ICollection<SocietyRepresentativeApplication> RepresentativeApplications { get; set; }
        public ICollection<SocietyPost> Posts { get; set; }

    }
}