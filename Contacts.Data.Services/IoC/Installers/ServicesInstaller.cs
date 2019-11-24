using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Contacts.Data.Api.Services;
using Contacts.Data.Api.Implementation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Data.Services.IoC.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IContactDataService>().ImplementedBy<ContactDataService>().LifestyleTransient());
        }
    }
}