using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using AgileTickets.Web.Models;

namespace AgileTickets.Web.Infra.Database
{
    public class EstabelecimentoMap : ClassMap<Estabelecimento>
    {
        public EstabelecimentoMap()
        {
            Id(e => e.Id);
            Map(e => e.Nome);
            Map(e => e.Endereco);
        }
    }
}