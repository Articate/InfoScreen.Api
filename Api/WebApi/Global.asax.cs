using System;
using System.Web.Http;
using Castle.Windsor;
using InfoScreen.WebApi.Infrastructure;

namespace InfoScreen.WebApi
{
    public class Global : System.Web.HttpApplication
    {
        private WindsorContainer _container = new WindsorContainer();

        protected void Application_Start(object sender, EventArgs e)
        {
            // Init Dependency Injection
            _container.Install(new WebApiInstaller());

            var apiConfiguration = _container.Resolve<ApiConfiguration>();
            GlobalConfiguration.Configure(apiConfiguration.ApiConfigSetup);

            // Init Json formatters
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IocCustomCreationConverter<IPasienthendelseDto>());
        }
    }
}