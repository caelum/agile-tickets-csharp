using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTickets.Web.Models
{
    public class Estabelecimento
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual String Endereco { get; set; }
    }
}