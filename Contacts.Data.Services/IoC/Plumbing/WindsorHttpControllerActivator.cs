using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Contacts.Data.Services.IoC.Plumbing
{
    public class WindsorHttpControllerActivator: IHttpControllerActivator
    {
        #region Declarations
        private readonly IKernel _kernel;
        #endregion Declarations

        #region Constructors
        public WindsorHttpControllerActivator(IKernel kernel)
        {
            _kernel = kernel;
        }
        #endregion Constructors

        #region IHttpControllerActivator Implementations
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(500, "Error, could not find api controller");
            }

            return (IHttpController)_kernel.Resolve(controllerType);
        }
        #endregion IHttpControllerActivator Implementations
    }
}