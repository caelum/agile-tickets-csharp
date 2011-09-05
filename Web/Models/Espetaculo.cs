using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTickets.Web.Models
{
    public class Espetaculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IList<Sessao> Sessoes { get; set; }
        private Estabelecimento Estabelecimento { get; set; }

        public List<Sessao> CriaSessoes(DateTime inicio, DateTime fim, Periodicidade periodicidade)
        {
            return null;
        }
    }
}