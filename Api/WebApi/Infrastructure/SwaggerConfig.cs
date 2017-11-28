namespace InfoScreen.WebApi.Infrastructure
{
    public class SwaggerConfig : ISwaggerConfig
    {
        public string SwaggerMiljø => Config.Get("SwaggerMiljø");

        public string SwaggerBackgroundColor => Config.Get("SwaggerBackgroundColor");

        public string SwaggerHeaderColor => Config.Get("SwaggerHeaderColor");

        public string SwaggerRoot => Config.Get("SwaggerRoot");
    }
}