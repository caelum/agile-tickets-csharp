using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileTickets.Web.Repositorios;

namespace AgileTickets.Web.Controllers
{
    public class EstabelecimentosController : Controller
    {
        private DiretorioDeEstabelecimentos estabelecimentos;

        public EstabelecimentosController(DiretorioDeEstabelecimentos estabelecimentos)
        {
            this.estabelecimentos = estabelecimentos;
        }

        public ActionResult Index()
        {
            return View(estabelecimentos.Todos());
        }

    }
}
