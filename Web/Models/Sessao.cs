using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileTickets.Web.Models
{
    public class Sessao
    {
        public int Id { get; set; }
        public Espetaculo Espetaculo { get; set; }
        public int TotalDeIngressos { get; set; }
        public int IngressosReservados { get; set; }
        public DateTime Inicio { get; set; }

        public bool PodeReservar(int NumeroDeIngressos)
        {
            return TotalDeIngressos > NumeroDeIngressos;
        }

    }
}
