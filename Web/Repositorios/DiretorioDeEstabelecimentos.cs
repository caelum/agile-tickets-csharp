using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileTickets.Web.Models;

namespace AgileTickets.Web.Repositorios
{
    public interface DiretorioDeEstabelecimentos
    {
        IList<Estabelecimento> Todos();

        void Salva(Estabelecimento estabelecimento);
    }
}