using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class SocietyRepresentativeApplication
    {
        [Key]
        public int ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
        public string? Reason { get; set; }
        public bool IsApproved { get; set; } = false;

        // Foreign Keys
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [ForeignKey("Society")]
        public int SocietyId { get; set; }
        public Society Society { get; set; }
    }
}