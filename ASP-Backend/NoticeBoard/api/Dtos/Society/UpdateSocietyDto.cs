using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Society
{
    public class UpdateSocietyDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}