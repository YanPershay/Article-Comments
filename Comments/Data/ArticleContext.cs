using Comments.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Article.Data
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }

    }
}
