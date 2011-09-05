using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileTickets.Web.Models;

namespace AgileTickets.Web.Models
{
    public class RelogioDoSistema : Relogio
    {

        public DateTime agora()
        {
            return DateTime.Now;
        }
    }
}