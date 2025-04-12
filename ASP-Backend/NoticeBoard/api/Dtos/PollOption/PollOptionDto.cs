using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.PollOption
{
    public class PollOptionDto
    {
        public int PollOptionId { get; set; }
        public string Text { get; set; }
        public int PollId { get; set; }
    }
}