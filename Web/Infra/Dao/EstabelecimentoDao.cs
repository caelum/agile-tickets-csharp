using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileTickets.Web.Repositorios;
using AgileTickets.Web.Models;
using NHibernate;

namespace AgileTickets.Web.Infra.Dao
{
    public class EstabelecimentoDao : DiretorioDeEstabelecimentos
    {
        private ISession session;

        public EstabelecimentoDao(ISession session)
        {
            this.session = session;
        }

        public IList<Estabelecimento> Todos()
        {
            return session.CreateCriteria<Estabelecimento>().List<Estabelecimento>();
        }
    }
}