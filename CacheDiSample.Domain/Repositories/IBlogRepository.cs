using System;
using CacheDiSample.Domain.Model;

namespace CacheDiSample.Domain.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog GetByName(string name);
    }
}
