
using BenchmarkDotNet.Running;
using ItPme;

BenchmarkRunner.Run<ParedeTijolos>();

// See https://aka.ms/new-console-template for more information

var paredeTijolos = new List<List<int>>()
{
    new List<int> { 1,3,1,1 },
    new List<int> { 3,1,2 },
    new List<int> { 2,4},
    new List<int> { 1,3,2 },
    new List<int> { 3,1,2 },
    new List<int> { 1,2,2,1 }
};


int comprimentoParede = paredeTijolos.First().Sum();
int qtdeLinhaVertical = comprimentoParede - 1;

int menorQuantidadeRecortes = qtdeLinhaVertical, regiaoLinhaVertical = 0;
for (int indexregiaoLinhaVertical = 1; indexregiaoLinhaVertical <= qtdeLinhaVertical; indexregiaoLinhaVertical++)
{
    int qtdeRecorteAtual = ParedeTijolos.BuscarQuantidadeDeRecortesTijolo(paredeTijolos, indexregiaoLinhaVertical);

    if (qtdeRecorteAtual < menorQuantidadeRecortes)
    {
        menorQuantidadeRecortes = qtdeRecorteAtual;
        regiaoLinhaVertical = indexregiaoLinhaVertical;
    }
}


Console.WriteLine($"A linha vertical que corta o menor número de tijolos é uma linha na posição {regiaoLinhaVertical} da parede");
Console.WriteLine($"cortando apenas {menorQuantidadeRecortes} tijolos");
