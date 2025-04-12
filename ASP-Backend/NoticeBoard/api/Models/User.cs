using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        // public bool IsAdmin { get; set; }
        // public bool IsDepartmentHead { get; set; }
        // public bool IsInterUniversityRep { get; set; }
        // public bool IsSocietyRep { get; set; }

        // Navigation Properties
        public ICollection<Notice> AuthoredNotices { get; set; }
        public ICollection<Event> AuthoredEvents { get; set; }
        public ICollection<Poll> AuthoredPolls { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<EventRating> EventRatings { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
        public ICollection<SocietyMembership> SocietyMemberships { get; set; }
        public ICollection<SocietyRepresentativeApplication> RepresentativeApplications { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public ICollection<PerkAssignment> PerkAssignments { get; set; }

    }
}