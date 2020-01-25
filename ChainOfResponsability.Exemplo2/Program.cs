using System;

namespace ChainOfResponsability.Exemplo2
{
    public class Program
    {
        // Aqui utilizamos o template method para realizar a corrente.
        static void Main(string[] args)
        {
            var debitoParaPagarNoNuBank = new Debito(EBanco.NuBank, 500);
            var debitoParaPagarNoItau = new Debito(EBanco.Itau, 300);
            var debitoParaPagarNoBradesco = new Debito(EBanco.Bradesco, 500);

            var realizarPagamento = new RealizarPagamento();

            realizarPagamento.EfetuarPagamento(debitoParaPagarNoItau);
            realizarPagamento.EfetuarPagamento(debitoParaPagarNoNuBank);
            realizarPagamento.EfetuarPagamento(debitoParaPagarNoBradesco);

            Console.ReadKey();
        }
    }
}
