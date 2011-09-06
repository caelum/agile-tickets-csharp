using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using AgileTickets.Web.Infra.Database;
using NHibernate;

namespace AgileTickets.Web.Infra.DI
{
    public class PersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            var config = DatabaseConfigurator.SetEntities().BuildConfiguration();

            Kernel.Register(
                Component.For<ISessionFactory>().UsingFactoryMethod(config.BuildSessionFactory),
                Component.For<ISession>().UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()).LifeStyle.PerWebRequest
                );
        }
    }
}