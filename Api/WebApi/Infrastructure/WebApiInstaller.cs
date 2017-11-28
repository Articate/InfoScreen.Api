namespace InfoScreen.WebApi.Infrastructure
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using InfoScreen.Service.Infrastructure;

    public class WebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IHttpControllerActivator>().Instance(new WindsorHttpControllerActivator(container)),
                Component.For<ApiConfiguration>(),
                //Component.For<IPasienthendelseDto>().ImplementedBy<PasienthendelseDto>().LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn(typeof(IConfig)).WithServiceAllInterfaces());

            var webApiAssembly = GetType().Assembly;
            var webApiControllers = Classes.FromAssembly(webApiAssembly).BasedOn<ApiController>();
            container.Register(webApiControllers.LifestyleTransient());

            container.Install(new ServiceInstaller());
        }
    }
}