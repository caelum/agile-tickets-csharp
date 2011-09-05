using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileTickets.Web.Infra.Database;
using AgileTickets.Web.Models;
using NHibernate.Tool.hbm2ddl;
using NHibernate;

namespace AgileTickets.Web.Controllers
{
    public class InfraController : Controller
    {
        private ISession session;

        public InfraController(ISession session)
        {
            this.session = session;
        }

        public ActionResult Tabelas()
        {
            new SchemaExport(DatabaseConfigurator.SetEntities().BuildConfiguration()).Execute(false, true, false);

            Estabelecimento morumbi = new Estabelecimento();
            morumbi.Nome = "Estádio do Morumbi";
            morumbi.Endereco = "São Paulo / SP";
            session.Save(morumbi);

            Espetaculo e1 = new Espetaculo();
            e1.Nome = "O Médico e o Monstro";
            e1.Descricao = "Espetáculo que se passa em Londres";
            e1.Estabelecimento = morumbi;
            session.Save(e1);

            Espetaculo e2 = new Espetaculo();
            e2.Nome = "Mamma Mia!";
            e2.Descricao = "Show muito legal!";
            e2.Estabelecimento = morumbi;
            session.Save(e2);

            return View();
        }
    }
}