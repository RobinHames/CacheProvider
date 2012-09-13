using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;

using CacheDiSample.Domain.CacheInterfaces;
using CacheDiSample.CacheProviders;

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

            container.Register(
                Component.For<ISqlCacheDependency>()
                .ImplementedBy<AspNetSqlCacheDependency>()
                .LifestyleTransient());

            container.Register(
                Component.For<IKeyCacheDependency>()
                .ImplementedBy<AspNetKeyCacheDependency>()
                .LifestyleTransient());

            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<ICacheDependencyFactory>()
                .AsFactory());
        }
    }
}