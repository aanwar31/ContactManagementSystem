using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Contacts.Common.Core.Utility.Implementation;
using Contacts.Common.Core.Utility.Interface;
using Contacts.Common.Proxy.RestProxy.Contract.ContactsDataService;
using Contacts.Common.Proxy.RestProxy.Impl.ContactDataService;
using System.Configuration;

namespace Contacts.IoC.Installers
{
    public class ServiceProxyInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Implementations
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            #region Container Registration for Logger
            container.Register(
                Component.For<IContactLogger>()
                    .ImplementedBy<ContactLogger>()
                    .LifestyleSingleton());
            #endregion Container Registration for Logger

            #region Container Registration for Service Proxy
            
            container.Register(
                Component.For<IContactDataServiceProxy>()
                    .ImplementedBy<ContactDataServiceProxy>()
                    .LifestyleSingleton()
                    .DependsOn(
                        new { baseAddress = ConfigurationManager.AppSettings["ServiceUrl"] }
                        ));

            #endregion Container Registration for Service Proxy

        }
        #endregion IWindsorInstaller Implementations

    }
}