using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileTickets.Web.Models;

namespace AgileTickets.Web.Repositorios
{
    public interface Agenda
    {
        IList<Espetaculo> espetaculos();
        void cadastra(Espetaculo espetaculo);
        Sessao sessao(long sessaoId);
        IList<Sessao> proximasSessoes(int maximo);
        void agende(List<Sessao> sessoes);
    }
}