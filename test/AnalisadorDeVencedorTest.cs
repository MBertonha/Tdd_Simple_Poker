using System.Collections.Generic;
using Desafio_Poker_Simples.src;
using Xunit;

namespace Desafio_Poker_Simples.test
{
    public class AnalisadorDeVencedorTest
    {
        [Fact]
        public void DeveAnalisarVencedror()
        {
            const string vencedorEsperado = "Jogador 2";
            var cartasJogador1 = new List<string> { "2O", "4C", "3P", "6C", "7C" };
            var cartasJogador2 = new List<string> { "3O", "5C", "2E", "9C", "7P" };

            var analisador = new AnalisadorDeVencedor();

            var vencedor = analisador.Analisar(cartasJogador1, cartasJogador2);

            Assert.Equal(vencedorEsperado, vencedor);
        }
    }
}
