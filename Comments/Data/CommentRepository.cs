using Article.Data.Interfaces;
using Comments.Data.Models;
using System;
using System.Collections.Generic;

namespace Article.Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ArticleContext _context;

        public CommentRepository(ArticleContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> AllComments => _context.Comments;

        public void CreateComment(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
