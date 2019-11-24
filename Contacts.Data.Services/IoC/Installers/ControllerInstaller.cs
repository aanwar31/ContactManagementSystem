using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Contacts.Data.Services.IoC.Installers
{
    public class ControllerInstaller: IWindsorInstaller
    {
        #region IWindsorInstaller Implementations
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            //foreach (var types in assemblies.Select(assembly => assembly.DefinedTypes))
            //{
            //    container.Register(
            //        Types.From(types)
            //            .BasedOn<IHttpController>()
            //            .LifestyleTransient());

            //}
            container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient());
        }
        #endregion IWindsorInstaller Implementations
    }
}