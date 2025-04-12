using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Poll
{
    public class UpdatePollDto
    {
        public string Question { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}