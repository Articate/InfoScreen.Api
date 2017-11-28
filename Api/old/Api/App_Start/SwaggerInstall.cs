using System;
using System.Collections.Generic;
using System.Web.Http;
using Swashbuckle.Application;

namespace InfoScreen.Api.Infrastructure
{
    public static class SwaggerInstall
    {
        private static ISwaggerConfig Config { get; set; }

        public static void Register(HttpConfiguration httpConfig, ISwaggerConfig config)
        {
            var thisAssembly = typeof(SwaggerInstall).Assembly;
            Config = config;

            httpConfig
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", string.Empty);
                    c.UseFullTypeNameInSchemaIds();
                    GetXmlCommentsPath().ForEach(c.IncludeXmlComments);
                })
                .EnableSwaggerUi(c =>
                {
                    c.InjectStylesheet(thisAssembly, "Hdir.Meldeordningen.WebApi.Content.swagger.custom-swagger.css");
                    c.CustomAsset("index", thisAssembly, "Hdir.Meldeordningen.WebApi.Content.swagger.index.html");
                    c.DisableValidator();
                });
        }

        private static List<string> GetXmlCommentsPath()
        {
            return new List<string>
            {
                $@"{AppDomain.CurrentDomain.BaseDirectory}Documentation\Hdir.Meldeordningen.WebApi.XML",
                $@"{AppDomain.CurrentDomain.BaseDirectory}Documentation\Hdir.Meldeordningen.Felles.XML"
            };
        }
    }
}
