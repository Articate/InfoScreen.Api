using System;
using System.Collections.Generic;
using System.Web.Http;
using Swashbuckle.Application;
using InfoScreen.WebApi.Infrastructure;

namespace InfoScreen.WebApi
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
                    c.InjectStylesheet(thisAssembly, "InfoScreen.WebApi.Content.swagger.custom-swagger.css");
                    c.CustomAsset("index", thisAssembly, "InfoScreen.WebApi.Content.swagger.index.html");
                    c.DisableValidator();
                });
        }

        private static List<string> GetXmlCommentsPath()
        {
            return new List<string>
            {
                $@"{AppDomain.CurrentDomain.BaseDirectory}Documentation\InfoScreen.WebApi.XML",
            };
        }
    }
}
