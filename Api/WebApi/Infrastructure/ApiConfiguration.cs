using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace InfoScreen.WebApi.Infrastructure
{
    public class ApiConfiguration
    {
        private readonly ISwaggerConfig _swaggerConfig;
        private readonly IHttpControllerActivator _httpControllerActivator;

        public ApiConfiguration(ISwaggerConfig swaggerConfig, IHttpControllerActivator httpControllerActivator)
        {
            _swaggerConfig = swaggerConfig;
            _httpControllerActivator = httpControllerActivator;
        }

        public void ApiConfigSetup(HttpConfiguration httpConfiguration)
        {
            WebApiConfig.Register(httpConfiguration);
            SwaggerInstall.Register(httpConfiguration, _swaggerConfig);
            httpConfiguration.Services.Replace(typeof(IHttpControllerActivator), _httpControllerActivator);
        }
    }
}