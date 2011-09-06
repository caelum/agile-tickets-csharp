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
    public class EstabelecimentosController : Controller
    {
        private DiretorioDeEstabelecimentos estabelecimentos;

        public EstabelecimentosController(DiretorioDeEstabelecimentos estabelecimentos)
        {
            // guarda estabelecimento
            this.estabelecimentos = estabelecimentos;
        }

        public ActionResult Index()
        {
            return View(estabelecimentos.Todos());
        }

        [RequiresTransaction]
        public ActionResult Novo(Estabelecimento estabelecimento)
        {
            var copia = estabelecimento;

            estabelecimentos.Salva(estabelecimento);

            // redireciona
            return RedirectToAction("Index");
        }

        private Estabelecimento PopulaEstabelecimento() 
        {
            Estabelecimento e = new Estabelecimento();
            return e;
        }
    }
}
