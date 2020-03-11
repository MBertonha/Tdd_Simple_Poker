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
            var cartasDuplicadosDoJogador1 = cartasJogador1
                .Select(carta => ConverterParaValorDaCarta(carta))
                .GroupBy(valorDaCarta => valorDaCarta)
                .Where(grupo => grupo.Count() > 1);

            var cartasDuplicadosDoJogador2 = cartasJogador2
                .Select(carta => ConverterParaValorDaCarta(carta))
                .GroupBy(valorDaCarta => valorDaCarta)
                .Where(grupo => grupo.Count() > 1);

            if (cartasDuplicadosDoJogador1 != null && cartasDuplicadosDoJogador1.Any() &&
                    cartasDuplicadosDoJogador2 != null && cartasDuplicadosDoJogador2.Any())
            {
                var maiorParDeCartasDoJogador1 = cartasDuplicadosDoJogador1.Select(valor => valor.Key)
                    .OrderBy(valor => valor)
                    .Max();
                var maiorParDeCartasDoJogador2 = cartasDuplicadosDoJogador2.Select(valor => valor.Key)
                    .OrderBy(valor => valor)
                    .Max();

                if (maiorParDeCartasDoJogador1 > maiorParDeCartasDoJogador2)
                {
                    return "Jogador 1";
                }
                else if (maiorParDeCartasDoJogador2 > maiorParDeCartasDoJogador1)
                {
                    return "Jogador 2";
                }
            }
            else if (cartasDuplicadosDoJogador1 != null && cartasDuplicadosDoJogador1.Any())
            {
                return "Jogador 1";
            }
            else if (cartasDuplicadosDoJogador2 != null && cartasDuplicadosDoJogador2.Any())
            {
                return "Jogador 2";
            }

            var maiorCartaDoJogador1 = cartasJogador1
                .Select(carta => ConverterParaValorDaCarta(carta))
                .OrderBy(valorDaCarta => valorDaCarta)
                .Max();

            var maiorCartaDoJogador2 = cartasJogador2
                .Select(carta => ConverterParaValorDaCarta(carta))
                .OrderBy(valorDaCarta => valorDaCarta)
                .Max();

            return maiorCartaDoJogador1 > maiorCartaDoJogador2 ? "Jogador 1" : "Jogador 2";
        }

        private int ConverterParaValorDaCarta(string carta)
        {
            var valorDaCarta = carta.Substring(0, carta.Length - 1);
            if (!int.TryParse(valorDaCarta, out var valor))
            {
                switch (valorDaCarta)
                {
                    case "V":
                        valor = 11;
                        break;
                    case "D":
                        valor = 12;
                        break;
                    case "R":
                        valor = 13;
                        break;
                    case "A":
                        valor = 14;
                        break;
                }
            }
            return valor;
        }
    }
}
