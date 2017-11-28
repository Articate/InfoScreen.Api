namespace InfoScreen.Service.Infrastructure
{
    class ServiceFactory : IServiceFactory
    {
        public T GetInstance<T>()
        {
            return ServiceInstaller.Container.Resolve<T>();
        }
    }
}
