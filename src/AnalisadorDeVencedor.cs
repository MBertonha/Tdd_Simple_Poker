using System.Linq;
using System;
using System.Collections.Generic;

namespace Desafio_Poker_Simples.src
{
    public class AnalisadorDeVencedor
    {
        public AnalisadorDeVencedor()
        {
        }

        public string Analisar(List<string> cartasJogador1, List<string> cartasJogador2)
        {
            var maiorCartaDoJogador1 = cartasJogador1
                .Select(carta => int.Parse(carta.Substring(0, 1)))
                .OrderBy(valorDaCarta => valorDaCarta)
                .Max();
            var maiorCartaDoJogador2 = cartasJogador2
                .Select(carta => int.Parse(carta.Substring(0, 1)))
                .OrderBy(valorDaCarta => valorDaCarta)
                .Max();

            return maiorCartaDoJogador1 > maiorCartaDoJogador2 ? "Jogador 1" : "Jogador 2";
        }
    }
}
