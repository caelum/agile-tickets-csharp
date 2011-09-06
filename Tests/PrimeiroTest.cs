using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    // Toda classe de teste deve ser anotada com TestFixture.
    [TestFixture]
    public class PrimeiroTest
    {
        // Todo método de teste deve ser anotado com Test.
        [Test]
        public void DeveAcumularOValorPassado()
        {
            // Todo teste é igual e podemos dividi-lo em 3 partes: Cenário, Execução, e Validação.

            // Aqui estamos montando o cenário. Criamos o acumulador e o valor a ser passado pra ele
            // Nesse caso, vamos passar o valor 10 e ver o que acontece.
            Acumulador acumulador = new Acumulador();
            int valorASerAcumulado = 10;

            // Agora vamos executar o comportamento que queremos testar. No caso, "Acumula"
            acumulador.Acumula(valorASerAcumulado);

            // Agora vamos validar a saída. Dado o cenário que passamos (valor 10), esperamos
            // o valor acumulado ao final seja 10.
            Assert.AreEqual(10, acumulador.ValorAcumulado);
        }

        // E este teste abaixo, o que faz?
        [Test]
        public void DeveAcumularVariosValoresPassados()
        {
            Acumulador acumulador = new Acumulador();

            acumulador.Acumula(10);
            acumulador.Acumula(20);
            acumulador.Acumula(20);
            
            Assert.AreEqual(50, acumulador.ValorAcumulado);
        }

    }

    // A classe acumulador está aqui apenas para facilitar este exemplo.
    // No mundo real, essa classe ficaria em outro arquivo (até mesmo em outra dll)
    class Acumulador
    {
        public int ValorAcumulado { get; private set; }
        public void Acumula(int valor)
        {
            this.ValorAcumulado += valor;
        }

    }

}
