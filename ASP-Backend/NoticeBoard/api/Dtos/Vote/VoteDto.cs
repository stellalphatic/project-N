using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Vote
{
    public class VoteDto
    {
        public int VoteId { get; set; }
        public DateTime VoteDate { get; set; }
        public string UserId { get; set; }
        public int PollOptionId { get; set; }
    }
}