using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;

namespace AgileTickets.Web.Infra.DI
{
    public class DaoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                .Where(Component.IsInNamespace("AgileTickets.Web.Infra.Dao"))
                .WithService.AllInterfaces()
                .Configure(c => c.LifeStyle.Transient));
        }
    }
}