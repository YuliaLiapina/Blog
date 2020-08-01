using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("DefaultConnection")
        {
            Database.SetInitializer(new BlogInicializer());
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
