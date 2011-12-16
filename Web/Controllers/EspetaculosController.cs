using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileTickets.Web.Repositorios;
using AgileTickets.Web.Models;
using AgileTickets.Web.Infra.Database;

namespace AgileTickets.Web.Controllers
{
    public class EspetaculosController : Controller
    {
        private Agenda agenda;
        private DiretorioDeEstabelecimentos estabelecimentos;

        public EspetaculosController(Agenda agenda, DiretorioDeEstabelecimentos estabelecimentos)
        {
            this.agenda = agenda;
            this.estabelecimentos = estabelecimentos;
        }

        public ActionResult Index()
        {
            ViewBag.Estabelecimentos = estabelecimentos.Todos();
            return View(agenda.Espetaculos());
        }

        [RequiresTransaction]
        public ActionResult Novo(Espetaculo espetaculo) {
            agenda.Cadastra(espetaculo);

            return RedirectToAction("Index");
        }

        private ActionResult VoltaPraIndex()
        {
            return RedirectToAction("Index");
        }

    }
}
