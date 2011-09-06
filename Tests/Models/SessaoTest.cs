using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AgileTickets.Web.Models;

namespace Tests.Models
{
    [TestFixture]
    public class SessaoTest
    {
        [Test]
        public void DeveVender1IngressoSeHa2Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 2;

            Assert.IsTrue(sessao.PodeReservar(1));
        }

        [Test]
        public void NaodeveVender3IngressoSeHa2Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 2;

            Assert.IsFalse(sessao.PodeReservar(3));
        }

        [Test]
        public void ReservarIngressosDeveDiminuirONumeroDeIngressosDisponiveis()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 5;

            sessao.Reserva(3);
            Assert.AreEqual(2, sessao.IngressosDisponiveis);
        }
    }
}
