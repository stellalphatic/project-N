using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Vote
{
    public class CreateVoteDto
    {
        public int PollOptionId { get; set; }
        // UserId will be obtained from the authenticated user
    }
}