using System;
using System.Collections.Generic;
using System.Linq;

using CacheDiSample.Domain.Model;
using CacheDiSample.Domain.Repositories;

namespace CacheDiSample.DataAccess
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : EntityBase
    {
        protected readonly BloggingContext bloggingContext;

        public RepositoryBase(string nameOrConnectionString)
        {
            this.bloggingContext = new BloggingContext(nameOrConnectionString);
        }

        public virtual T GetById(int id)
        {
            return bloggingContext.Set<T>().Find(id);
        }

        public virtual IList<T> GetAll()
        {
            return bloggingContext.Set<T>().ToList();
        }
    }
}
