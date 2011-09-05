using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileTickets.Web.Repositorios;
using AgileTickets.Web.Models;

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
            ViewBag["Espetaculos"] = agenda.espetaculos();

            return View();
        }

    }
}
