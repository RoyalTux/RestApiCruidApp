using Microsoft.EntityFrameworkCore;
using RestApiCruidApp.Models;

namespace RestApiCruidApp.Data
{
    public class BlogPostsContext : DbContext
    {
        public BlogPostsContext (DbContextOptions<BlogPostsContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
    }
}
