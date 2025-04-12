using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.SocietyPosts
{
    public class UpdateSocietyPostDto
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string? ImageUrl { get; set; }

    }
}