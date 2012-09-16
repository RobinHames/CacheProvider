using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CacheDiSample.Domain.Model;
using CacheDiSample.Domain.CacheInterfaces;
using CacheDiSample.Domain.Repositories;

namespace CacheDiSample.Domain.CacheDecorators
{
    public class BlogRepositoryWithCaching : IBlogRepository
    {
        // The generic cache provider, injected by DI
        private ICacheProvider<Blog> cacheProvider;
        // The decorated blog repository, injected by DI
        private IBlogRepository parentBlogRepository;

        public BlogRepositoryWithCaching(IBlogRepository parentBlogRepository, ICacheProvider<Blog> cacheProvider)
        {
            if (parentBlogRepository == null)
                throw new ArgumentNullException("parentBlogRepository");

            this.parentBlogRepository = parentBlogRepository;

            if (cacheProvider == null)
                throw new ArgumentNullException("cacheProvider");

            this.cacheProvider = cacheProvider;
        }

        public Blog GetByName(string name)
        {
            string key = string.Format("CacheDiSample.DataAccess.GetByName.{0}", name);
            // hard code 5 minute expiry!
            TimeSpan relativeCacheExpiry = new TimeSpan(0, 5, 0);
            return cacheProvider.Fetch(key, () =>
            {
                return parentBlogRepository.GetByName(name);
            },
                null, relativeCacheExpiry);
        }

        public Blog GetById(int id)
        {
            string key = string.Format("CacheDiSample.DataAccess.GetById.{0}", id);

            // hard code 5 minute expiry!
            TimeSpan relativeCacheExpiry = new TimeSpan(0, 5, 0);
            return cacheProvider.Fetch(key, () =>
            {
                return parentBlogRepository.GetById(id);
            },
                null, relativeCacheExpiry);
        }

        public IList<Blog> GetAll()
        {
            var sqlCacheDependency = cacheProvider.CreateCacheDependency<ISqlCacheDependency>()
                .Initialise("BloggingContext", "Blogs");

            ICacheDependency[] cacheDependencies = new ICacheDependency[] { sqlCacheDependency };

            string key = string.Format("CacheDiSample.DataAccess.GetAll");

            return cacheProvider.Fetch(key, () =>
            {
                return parentBlogRepository.GetAll();
            },
                null, null, cacheDependencies)
            .ToList();
        }
    }
}
