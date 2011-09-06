using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AgileTickets.Web.Models;

namespace Tests.Models
{
    [TestFixture]
    public class EspetaculoTests
    {
        [Test]
        public void DeveInformarSeEhPossivelReservarAQuantidadeDeIngressosDentroDeQualquerDasSessoes()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(1));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));

            Assert.IsTrue(ivete.Vagas(5));
        }

        [Test]
        public void DeveInformarSeEhPossivelReservarAQuantidadeExataDeIngressosDentroDeQualquerDasSessoes()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(1));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));

            Assert.IsTrue(ivete.Vagas(6));
        }

        [Test]
        public void DeveInformarSeNaoEhPossivelReservarAQuantidadeDeIngressosDentroDeQualquerDasSessoes()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(1));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));

            Assert.IsFalse(ivete.Vagas(15));
        }

        [Test]
        public void DeveInformarSeEhPossivelReservarAQuantidadeDeIngressosDentroDeQualquerDasSessoesComUmMinimoPorSessao()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(4));

            Assert.IsTrue(ivete.Vagas(5, 3));
        }

        [Test]
        public void DeveInformarSeEhPossivelReservarAQuantidadeExataDeIngressosDentroDeQualquerDasSessoesComUmMinimoPorSessao()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(3));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(4));

            Assert.IsTrue(ivete.Vagas(10, 3));
        }

        [Test]
        public void DeveInformarSeNaoEhPossivelReservarAQuantidadeDeIngressosDentroDeQualquerDasSessoesComUmMinimoPorSessao()
        {
            Espetaculo ivete = new Espetaculo();

            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));
            ivete.Sessoes.Add(SessaoComIngressosSobrando(2));

            Assert.IsFalse(ivete.Vagas(5, 3));
        }

        private Sessao SessaoComIngressosSobrando(int quantidade)
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = quantidade * 2;
            sessao.IngressosReservados = quantidade;

            return sessao;
        }
    }
}
