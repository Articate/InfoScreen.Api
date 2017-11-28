namespace InfoScreen.WebApi.Infrastructure
{
    public interface ISwaggerConfig : IConfig
    {
        string SwaggerMiljø { get; }

        string SwaggerBackgroundColor { get; }

        string SwaggerHeaderColor { get; }

        string SwaggerRoot { get; }
    }
}