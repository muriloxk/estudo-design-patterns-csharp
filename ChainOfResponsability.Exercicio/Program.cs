using System;

namespace ChainOfResponsability.Exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            var requisicao = new Requisicao(EFormato.PORCENTO);
            var servidor = new CriarReposta();

            Console.WriteLine($"Resposta do servidor: {servidor.GerarResposta(requisicao)}");
            Console.ReadKey();
        }
    }
}
