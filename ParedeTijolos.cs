using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

namespace ItPme
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Arabic)]
    [MarkdownExporter]
    public class ParedeTijolos
    {
        internal static int BuscarQuantidadeDeRecortesTijolo(List<List<int>> paredeTijolos, int recorte)
        {
            int quantidadeTijolosRecortados = 0;
            foreach (var linhaTijolo in paredeTijolos)
            {
                var tamanho = 0;
                foreach (var tijolo in linhaTijolo)
                {
                    tamanho += tijolo;
                    if (tamanho < recorte)
                        continue;

                    if (tamanho == recorte)
                    {
                        break;
                    }
                    quantidadeTijolosRecortados++;
                    break;
                }
            }
            return quantidadeTijolosRecortados;
        }


        [Benchmark(Description = "BuscarQuantidadeDeRecortesTijolo")]
        public void BuscarQuantidadeDeRecortesTijolo()
        {
            var paredeTijolos = new List<List<int>>()
            {
                new List<int> { 1,3,1,1 },
                new List<int> { 3,1,2 },
                new List<int> { 2,4},
                new List<int> { 1,3,2 },
                new List<int> { 3,1,2 },
                new List<int> { 1,2,2,1 }
            };


            BuscarQuantidadeDeRecortesTijolo(paredeTijolos, paredeTijolos.First().Sum());
        }
    }
}