using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Notice
{
    public class NoticeDto
    {
        public int NoticeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPinned { get; set; }
        public string AuthorId { get; set; }
    }
}