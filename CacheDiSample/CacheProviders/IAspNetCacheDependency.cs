using System.Web.Caching;

namespace CacheDiSample.CacheProviders
{
    public interface IAspNetCacheDependency
    {
        CacheDependency CreateAspNetCacheDependency();
    }
}
