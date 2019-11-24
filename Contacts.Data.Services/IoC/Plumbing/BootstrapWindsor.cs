using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Contacts.Data.Services.IoC.Plumbing
{
    public class BootstrapWindsor
    {
        #region Declarations
        private static IWindsorContainer _container;
        #endregion Declarations

        #region Methods
        public static void Bootstrap()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());

            var httpActivator = new WindsorHttpControllerActivator(_container.Kernel);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), httpActivator);
        }

        public static void Cleanup()
        {
            if (_container != null)
            {
                _container.Dispose();
            }
        }
        #endregion Methods
    }
}