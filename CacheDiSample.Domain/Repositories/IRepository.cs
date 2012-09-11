using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
