using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTickets.Web.Models
{
    public class Espetaculo
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual IList<Sessao> Sessoes { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }

        public virtual List<Sessao> CriaSessoes(DateTime inicio, DateTime fim, Periodicidade periodicidade)
        {
            return null;
        }
    }
}