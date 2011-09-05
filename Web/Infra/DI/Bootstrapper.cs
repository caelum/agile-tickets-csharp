using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using NHibernate;
using Unity;
using AgileTickets.Web.Models;
using AgileTickets.Web.Repositorios;
using AgileTickets.Web.Infra.Dao;
using AgileTickets.Web.Infra.Database;

namespace AgileTickets.Web.Infra.DI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<Agenda, AgendaDao>();
            container.RegisterType<DiretorioDeEstabelecimentos, EstabelecimentoDao>();
            container.RegisterType<Relogio, RelogioDoSistema>();

            container.RegisterControllers();
            ConfigureNHibernate(container);

            return container;
        }

        private static void ConfigureNHibernate(UnityContainer container)
        {
            container.RegisterInstance<ISessionFactory>(Database.DatabaseConfigurator.CreateSessionFactory());
            container.RegisterType<ISession>(new HttpContextLifetimeManager<ISession>(session => session.Close() != null), new InjectionFactory(c =>
            {
                return container.Resolve<ISessionFactory>().OpenSession();
            }));

        }
    }
}