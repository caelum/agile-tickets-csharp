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

        public EspetaculosController(Agenda agenda)
        {
            this.agenda = agenda;
        }

        public ActionResult Index()
        {
            return View(agenda.Espetaculos());
        }

    }
}
