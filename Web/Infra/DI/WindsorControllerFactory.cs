using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel;
using System.Web.Mvc;
using System.Web.Routing;

namespace AgileTickets.Web.Infra.DI
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public WindsorControllerFactory(IKernel iKernel)
        {
            this.kernel = iKernel;
        }

        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                base.GetControllerInstance(requestContext, controllerType);
            }

            var controller = kernel.Resolve(controllerType) as Controller;

            if (controller != null) 
            {
                controller.ActionInvoker = new WindsorActionInvoker(kernel);
            }

            return controller;
        }
    }
}