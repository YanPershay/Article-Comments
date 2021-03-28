using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ParentCommentId { get; set; }
        public string CommentText { get; set; }
        public string Author { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
