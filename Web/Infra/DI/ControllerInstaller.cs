using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using System.Web.Mvc;

namespace AgileTickets.Web.Infra.DI
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                .BasedOn<IController>()
                .If(Component.IsInNamespace("AgileTickets.Web.Controllers", true))
                .If(t => t.Name.EndsWith("Controller"))
                .Configure(c => c.LifeStyle.Transient));
        }
    }
}