using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using CacheDiSample.Domain;
using CacheDiSample.CacheProvider;

namespace CacheDiSample.WindsorInstallers
{
    public class CacheInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(ICacheProvider<>))
                .ImplementedBy(typeof(CacheProvider<>))
                .LifestyleTransient());
        }
    }
}