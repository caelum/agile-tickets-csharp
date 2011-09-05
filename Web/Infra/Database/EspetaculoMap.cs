using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using AgileTickets.Web.Models;

namespace AgileTickets.Web.Infra.Database
{
    public class EspetaculoMap : ClassMap<Espetaculo>
    {
        public EspetaculoMap()
        {
            Id(c => c.Id);
            Map(c => c.Descricao);
            Map(c => c.Nome);
            HasMany(c => c.Sessoes);
        }
    }
}