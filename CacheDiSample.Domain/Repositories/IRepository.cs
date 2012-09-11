using System;
using System.Collections.Generic;

using CacheDiSample.Domain.Model;

namespace CacheDiSample.Domain.Repositories
{
    public interface IRepository<T>
        where T : EntityBase
    {
        T GetById(int id);
        IList<T> GetAll();
    }
}
