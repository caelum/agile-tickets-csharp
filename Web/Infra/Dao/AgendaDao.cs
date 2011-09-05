using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileTickets.Web.Repositorios;
using AgileTickets.Web.Models;
using NHibernate;

namespace AgileTickets.Web.Infra.Dao
{
    public class AgendaDao : Agenda
    {
        private ISession session;
        private Relogio relogio;

        public AgendaDao(ISession session, Relogio relogio) {
            this.session = session;
            this.relogio = relogio;
        }

        public IList<Espetaculo> Espetaculos()
        {
            return session.CreateCriteria<Espetaculo>().List<Espetaculo>();
        }


        public void Cadastra(Espetaculo espetaculo)
        {
            session.Save(espetaculo);
        }

        public Sessao Sessao(long sessaoId)
        {
            return session.Load<Sessao>(sessaoId);
        }

        public IList<Sessao> ProximasSessoes(int maximo)
        {
            return session.CreateQuery("select s from Sessao s where s.inicio > :hoje order by s.inicio")
                .SetParameter<DateTime>("hoje", relogio.agora())
                .SetMaxResults(maximo)
                .List<Sessao>();
        }

        public void Agende(List<Sessao> sessoes)
        {
            foreach (Sessao novaSessao in sessoes)
            {
                session.Save(novaSessao);
            }
        }
    }
}