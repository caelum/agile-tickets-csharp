using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTickets.Web.Models
{
    public class Espetaculo
    {
        // propriedades
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual IList<Sessao> Sessoes { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }

        public Espetaculo()
        {
            this.Sessoes = new List<Sessao>();
        }
        /*
         * Esse metodo eh responsavel por criar sessoes para
         * o respectivo espetaculo, dado o intervalo de inicio e fim,
         * mais a periodicidade.
         * 
         * O algoritmo funciona da seguinte forma:
         * - Caso a data de inicio seja 01/01/2010, a data de fim seja 03/01/2010,
         * e a periodicidade seja DIARIA, o algoritmo cria 3 sessoes, uma 
         * para cada dia: 01/01, 02/01 e 03/01.
         * 
         * - Caso a data de inicio seja 01/01/2010, a data fim seja 31/01/2010,
         * e a periodicidade seja SEMANAL, o algoritmo cria 5 sessoes, uma
         * a cada 7 dias: 01/01, 08/01, 15/01, 22/01 e 29/01.
         * 
         * Repare que a data da primeira sessao é sempre a data inicial.
         */
        public virtual List<Sessao> CriaSessoes(DateTime inicio, DateTime fim, Periodicidade periodicidade)
        {
            // ALUNO: Não apague esse metodo. Esse sim será usado no futuro! ;)
            return null;
        }

        public virtual bool Vagas(int qtd, int min)
        {

            int totDisp = 0;

            foreach (Sessao s in Sessoes)
            {
                if (s.IngressosDisponiveis < min) return false;
                totDisp += s.IngressosDisponiveis;
            }

            if (totDisp >= qtd) return true;
            else return false;
        }

        public virtual bool Vagas(int qtd)
        {

            int totDisp = 0;

            foreach (Sessao s in Sessoes)
            {
                totDisp += s.IngressosDisponiveis;
            }

            if (totDisp >= qtd) return true;
            else return false;
        }
    }
}