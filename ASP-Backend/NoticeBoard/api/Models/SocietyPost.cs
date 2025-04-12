using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class SocietyPost
    {
        [Key]
        public int SocietyPostId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime PostDate { get; set; } = DateTime.UtcNow;
        public string? ImageUrl { get; set; } 

        // Foreign Key
        [ForeignKey("Society")]
        public int SocietyId { get; set; }
        public Society Society { get; set; }
    }

}