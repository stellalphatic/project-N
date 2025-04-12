using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        public string Text { get; set; }
        public int? NoticeId { get; set; }
        public int? EventId { get; set; }
        // UserId will be obtained from the authenticated user
    }
}