using Castle.MicroKernel;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Contacts.IoC.Plumbing
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        #region Declarations
        private readonly IWindsorContainer container;
        #endregion Declarations

        #region Constructors
        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }
        #endregion Constructors

        #region Methods
        #region DefaultControllerFactory Overrides
        public override void ReleaseController(IController controller)
        {
            container.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)container.Resolve(controllerType);
        }
        #endregion DefaultControllerFactory Overrides
        #endregion Methods
    }
}