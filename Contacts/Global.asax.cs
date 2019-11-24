using Castle.Windsor;
using Castle.Windsor.Installer;
using Contacts.Controllers;
using Contacts.IoC.Installers;
using Contacts.IoC.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Contacts
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            log4net.Config.XmlConfigurator.Configure();

            BootstrapContainer();
        }
        
        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}
