using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Poll
{
    public class CreatePollDto
    {
        public string Question { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        // AuthorId will be obtained from the authenticated user
    }
}