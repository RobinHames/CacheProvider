using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CacheDiSample.Domain.Model;
using CacheDiSample.Domain.Repositories;

namespace CacheDiSample.DataAccess
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public IList<Post> GetBlogPostByTitle(Blog blog, string title)
        {
            return bloggingContext.Posts.Where(p => p.Blog == blog && p.Title == title).ToList();
        }
    }
}
