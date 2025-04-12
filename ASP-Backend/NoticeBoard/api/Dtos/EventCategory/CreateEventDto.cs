using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.EventCategory
{
    public class CreateEventCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}