using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileTickets.Web.Models;

namespace AgileTickets.Web.Repositorios
{
    public interface Agenda
    {
        IList<Espetaculo> Espetaculos();
        void Cadastra(Espetaculo espetaculo);
        Sessao Sessao(long sessaoId);
        IList<Sessao> ProximasSessoes(int maximo);
        void Agende(List<Sessao> sessoes);
    }
}