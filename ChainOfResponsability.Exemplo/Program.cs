using System;

namespace ChainOfResponsability.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculadoraDeDescontos = new CalculadoraDeDescontos();

            var orcamento = new Orcamento();
            orcamento.AdicionarItem("Produto A", 100);
            orcamento.AdicionarItem("Produto B", 100);
            orcamento.AdicionarItem("Produto C", 100);
            orcamento.AdicionarItem("Produto D", 100);
            orcamento.AdicionarItem("Produto E", 100);
            orcamento.AdicionarItem("Produto F", 100);
            orcamento.AdicionarItem("Produto G", 100);
            orcamento.AdicionarItem("Produto H", 100);
            orcamento.AdicionarItem("Produto I", 100);
            orcamento.AdicionarItem("Produto J", 100);

            var desconto = calculadoraDeDescontos.Calcular(orcamento);

            Console.WriteLine(desconto);
            Console.ReadKey();
        }
    }
}
