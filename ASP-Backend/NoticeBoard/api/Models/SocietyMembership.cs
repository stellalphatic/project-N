using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class SocietyMembership
    {
        [Key]
        public int SocietyMembershipId { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [ForeignKey("Society")]
        public int SocietyId { get; set; }
        public Society Society { get; set; }
    }
}