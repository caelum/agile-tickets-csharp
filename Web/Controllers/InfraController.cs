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

            return View();
        }

        public ActionResult Cenario()
        {
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

            for (int i = 0; i < 10; i++)
            {
                Sessao sessao = new Sessao();
                sessao.Espetaculo = i%2 == 0 ? e1 : e2;
                sessao.TotalDeIngressos = 10;
                sessao.IngressosReservados = 10 - i;
                sessao.Inicio = DateTime.Now.AddDays(7 + i);

                session.Save(sessao);
            }

            return View();
        }
    }
}