using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using CacheDiSample.Domain;

namespace CacheDiSample.CacheProvider
{
    public class CacheProvider<T> : ICacheProvider<T>
    {
        public T Fetch(string key, Func<T> retrieveData, DateTime? absoluteExpiry, TimeSpan? relativeExpiry)
        {
            return FetchAndCache<T>(key, retrieveData, absoluteExpiry, relativeExpiry);
        }

        public IEnumerable<T> Fetch(string key, Func<IEnumerable<T>> retrieveData, DateTime? absoluteExpiry, TimeSpan? relativeExpiry)
        {
            return FetchAndCache<IEnumerable<T>>(key, retrieveData, absoluteExpiry, relativeExpiry);
        }

        #region Helper Methods

        //private U FetchAndCache<U>(string key, Func<U> retrieveData, DateTime? absoluteExpiry, TimeSpan? relativeExpiry, IEnumerable<ICacheDependency> cacheDependencies)
        private U FetchAndCache<U>(string key, Func<U> retrieveData, DateTime? absoluteExpiry, TimeSpan? relativeExpiry)
        {
            U value;
            if (!TryGetValue<U>(key, out value))
            {
                value = retrieveData();
                if (!absoluteExpiry.HasValue)
                    absoluteExpiry = Cache.NoAbsoluteExpiration;

                if (!relativeExpiry.HasValue)
                    relativeExpiry = Cache.NoSlidingExpiration;

                //CacheDependency aspNetCacheDependencies = null;

                //if (cacheDependencies != null)
                //{
                //    if (cacheDependencies.Count() == 1)
                //        // We know that the implementations of ICacheDependency will also implement IAspNetCacheDependency
                //        // so we can use a cast here and call the CreateAspNetCacheDependency() method
                //        aspNetCacheDependencies = ((IAspNetCacheDependency)cacheDependencies.ElementAt(0)).CreateAspNetCacheDependency();
                //    else if (cacheDependencies.Count() > 1)
                //    {
                //        AggregateCacheDependency aggregateCacheDependency = new AggregateCacheDependency();
                //        foreach (ICacheDependency cacheDependency in cacheDependencies)
                //        {
                //            // We know that the implementations of ICacheDependency will also implement IAspNetCacheDependency
                //            // so we can use a cast here and call the CreateAspNetCacheDependency() method
                //            aggregateCacheDependency.Add(((IAspNetCacheDependency)cacheDependency).CreateAspNetCacheDependency());
                //        }
                //        aspNetCacheDependencies = aggregateCacheDependency;
                //    }
                //}

                //HttpContext.Current.Cache.Insert(key, value, aspNetCacheDependencies, absoluteExpiry.Value, relativeExpiry.Value);
                HttpContext.Current.Cache.Insert(key, value, null, absoluteExpiry.Value, relativeExpiry.Value);

            }
            return value;
        }

        private bool TryGetValue<U>(string key, out U value)
        {
            object cachedValue = HttpContext.Current.Cache.Get(key);
            if (cachedValue == null)
            {
                value = default(U);
                return false;
            }
            else
            {
                try
                {
                    value = (U)cachedValue;
                    return true;
                }
                catch
                {
                    value = default(U);
                    return false;
                }
            }
        }

        #endregion

    }
}