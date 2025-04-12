using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Poll
{
    public class PollDto
    {
        public int PollId { get; set; }
        public string Question { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string AuthorId { get; set; }
    }
}