using System;
using System.Collections.Generic;

namespace CacheDiSample.Domain
{
    public interface ICacheProvider<T>
    {
        T Fetch(string key, Func<T> retrieveData, DateTime? absoluteExpiry, TimeSpan? relativeExpiry);
        //T Fetch(string key, Func<T> retrieveData, DateTime? absoluteExpiry, TimeSpan? relativeExpiry, IEnumerable<ICacheDependency> cacheDependencies);

        IEnumerable<T> Fetch(string key, Func<IEnumerable<T>> retrieveData, DateTime? absoluteExpiry, TimeSpan? relativeExpiry);
        //IEnumerable<T> Fetch(string key, Func<IEnumerable<T>> retrieveData, DateTime? absoluteExpiry, TimeSpan? relativeExpiry, IEnumerable<ICacheDependency> cacheDependencies);

    }
}
