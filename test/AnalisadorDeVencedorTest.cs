using System.Linq;
using System.Collections.Generic;
using Desafio_Poker_Simples.src;
using Xunit;

namespace Desafio_Poker_Simples.test
{
    public class AnalisadorDeVencedorTest
    {
        [Theory]
        [InlineData("3O,5C,2E,9C,7P", "2O,2C,3P,6C,7C", "Jogador 2")]
        [InlineData("DC,DO,3P,6C,7C", "3O,5C,2E,9C,7P", "Jogador 1")]
        public void DeveAnalisarVencedrorQuandoJogadorTiverMaiorCarta(string cartasDoJogador1String, string cartasDoJogador2String, string vencedorEsperado)
        {

            var cartasJogador1 = cartasDoJogador1String.Split(',').ToList();
            var cartasJogador2 = cartasDoJogador2String.Split(',').ToList();

            var analisador = new AnalisadorDeVencedor();

            var vencedor = analisador.Analisar(cartasJogador1, cartasJogador2);

            Assert.Equal(vencedorEsperado, vencedor);
        }
    }
}
