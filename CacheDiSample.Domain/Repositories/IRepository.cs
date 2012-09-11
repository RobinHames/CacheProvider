using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CacheDiSample.Domain.Model;

namespace CacheDiSample.Domain.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository
        where T : EntityBase
    {
        T GetById(int id);
        IList<T> GetAll();
    }
}
