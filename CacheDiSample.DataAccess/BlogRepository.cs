using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CacheDiSample.Domain.Model;
using CacheDiSample.Domain.Repositories;

namespace CacheDiSample.DataAccess
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public Blog GetByName(string name)
        {
            return bloggingContext.Blogs.Where(b => b.Name == name).FirstOrDefault();
        }
    }
}
