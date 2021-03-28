using Comments.Data.Models;
using System;
using System.Linq;

namespace Article.Data
{
    public class DbObjects
    {
        public static void Init(ArticleContext context)
        {

            if (!context.Comments.Any())
            {
                context.Comments.AddRange(

                    new Comment {
                        ParentCommentId = 0,
                        CommentText = "New comment",
                        Author = "Yan Pershay",
                        CommentDate = DateTime.Now
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
