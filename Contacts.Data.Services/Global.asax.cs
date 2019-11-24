using Contacts.Data.Api.Implementation.DataContext;
using Contacts.Data.Services.IoC.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Contacts.Data.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BootstrapWindsor.Bootstrap();

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());

            //log4net.Config.XmlConfigurator.Configure();

        }

        protected void Application_End()
        {
            BootstrapWindsor.Cleanup();
        }
    }
}
