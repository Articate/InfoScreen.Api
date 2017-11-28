using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace InfoScreen.Service.Infrastructure
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public static IWindsorContainer Container { get; private set; }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Container = container;

            container.Register(
                Component.For<IServiceFactory>().ImplementedBy<ServiceFactory>()
            );
        }
    }
}
