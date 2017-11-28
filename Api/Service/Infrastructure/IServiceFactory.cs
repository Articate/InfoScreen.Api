namespace InfoScreen.Service.Infrastructure
{
    public interface IServiceFactory
    {
        T GetInstance<T>();
    }
}
