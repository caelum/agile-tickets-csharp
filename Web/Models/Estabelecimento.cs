using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTickets.Web.Models
{
    public class Estabelecimento
    {
        // propriedade ID
        public virtual int Id { get; set; }
        // propriedade Nome
        public virtual string Nome { get; set; }
        // propriedade Endereco
        public virtual String Endereco { 
            // gera um get
            get; 
            // gera um set
            set; }
    }
}