using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheDiSample.Domain.CacheInterfaces
{
    public interface IKeyCacheDependency : ICacheDependency
    {
        string[] Keys { get; set; }
    }
}
