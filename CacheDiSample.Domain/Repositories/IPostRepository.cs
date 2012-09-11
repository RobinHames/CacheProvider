using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CacheDiSample.Domain.Model;

namespace CacheDiSample.Domain.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IList<Post> GetBlogPostByTitle(Blog blog, string title);
    }
}
