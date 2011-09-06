using System.Web.Mvc;
using System.Web.Routing;
using AgileTickets.Web.Infra.DI;
using System;
using AgileTickets.Web.Controllers;

using Castle.Facilities.FactorySupport;
using System.Web;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ReservarSessoes",
                "sessoes/{sessaoId}/reservar",
                new { controller = "Sessoes", action = "Reservar" }
            );

            routes.MapRoute(
                "ExibirSessoes",
                "sessoes/{sessaoId}",
                new { controller = "Sessoes", action = "Exibir" }
            );

            routes.MapRoute(
                "CriarSessoes",
                "espetaculos/{id}/sessoes/novo",
                new { controller = "Sessoes", action = "Criar" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            log4net.Config.XmlConfigurator.Configure();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BootstrapContainer();
        }

        private void BootstrapContainer()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.Containing<ControllerInstaller>());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}