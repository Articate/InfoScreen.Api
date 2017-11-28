namespace InfoScreen.Api.Infrastructure
{
    public interface ISwaggerConfig
    {
        string SwaggerMiljø { get; }

        string SwaggerBackgroundColor { get; }

        string SwaggerHeaderColor { get; }

        string SwaggerRoot { get; }
    }
}