using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using AgileTickets.Web.Models;

namespace AgileTickets.Web.Infra.Database
{
    public class SessaoMap : ClassMap<Sessao>
    {
        public SessaoMap()
        {
            Id(c => c.Id);
            Map(c => c.IngressosReservados);
            Map(c => c.TotalDeIngressos);
            References(c => c.Espetaculo);
            Map(c => c.Inicio);
        }
    }
}