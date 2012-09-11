using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using CacheDiSample.Domain.CacheDecorators;
using CacheDiSample.Domain.Repositories;
using CacheDiSample.DataAccess;

namespace CacheDiSample.WindsorInstallers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Classes.FromAssemblyContaining<CacheDiSample.DataAccess.BlogRepository>()
            //                    .BasedOn<CacheDiSample.Domain.Repositories.IRepository>()
            //                    .LifestyleTransient()
            //                    .Configure(component => component.DependsOn(new 
            //                    {
            //                        nameOrConnectionString = "BloggingContext"
            //                    })));

            // Use Castle Windsor implicit wiring for the block repository decorator
            // Register the outermost decorator first
            container.Register(Component.For<IBlogRepository>()
                .ImplementedBy<BlogRepositoryWithCaching>()
                .LifestyleTransient());
            // Next register the IBlogRepository inmplementation to inject into the outer decorator
            container.Register(Component.For<IBlogRepository>()
                .ImplementedBy<BlogRepository>()
                .LifestyleTransient()
                .DependsOn(new 
                                {
                                    nameOrConnectionString = "BloggingContext"
                                }));
        }
    }
}
