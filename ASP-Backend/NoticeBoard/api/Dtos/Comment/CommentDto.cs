using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        public string UserId { get; set; }
        public int? NoticeId { get; set; }
        public int? EventId { get; set; }
    }
}