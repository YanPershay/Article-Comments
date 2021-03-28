using Comments.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.Data.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> AllComments { get; }
        void CreateComment(Comment comment);
    }
}
