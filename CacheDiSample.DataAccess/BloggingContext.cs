using System;
using System.Data.Entity;

using CacheDiSample.Domain.Model;

namespace CacheDiSample.DataAccess
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
