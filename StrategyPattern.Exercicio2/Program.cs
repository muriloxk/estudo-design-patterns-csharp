using System;

namespace StrategyPattern.Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            var conta = new Conta(600);
            var realizadorInvestimento = new RealizadoraDeInvestimento();

            var conservador = realizadorInvestimento.RealizarInvestimento(conta, new Conservador());
            var moderado = realizadorInvestimento.RealizarInvestimento(conta, new Moderado());
            var arrojado = realizadorInvestimento.RealizarInvestimento(conta, new Arrojado());

            Console.WriteLine($"Conservador: {conservador}");
            Console.WriteLine($"Moderado: {moderado}");
            Console.WriteLine($"Arrojado: {arrojado}");

            Console.ReadKey();
        }
    }

    public interface Investimento
    {
        
        double Calcular(Conta conta);
    }

    public class Conta
    {
        public Conta(double saldo)
        {
            Saldo = saldo;
        }

        public double Saldo { get; set; }
    }

    public class Conservador : Investimento
    {
        const double RETORNO_INVESTIMENTO = 0.75;

        public double Calcular(Conta conta)
        {
            return (conta.Saldo * 0.008) * RETORNO_INVESTIMENTO;
        }
    }

    public class Moderado : Investimento
    {
        const double RETORNO_INVESTIMENTO = 0.75;

        public double Calcular(Conta conta)
        {
            var risco = new Random().Next(2);

            if (risco == 0)
            {
                return (conta.Saldo * 0.025) * RETORNO_INVESTIMENTO;
            }

            return (conta.Saldo * 0.0075) * RETORNO_INVESTIMENTO;
        }
    }

    public class Arrojado : Investimento
    {
        const double RETORNO_INVESTIMENTO = 0.75;

        public double Calcular(Conta conta)
        {
            var risco = new Random().Next(101);

            if (risco >= 0 && risco <= 20)
                return (conta.Saldo * 0.05) * RETORNO_INVESTIMENTO;

            if (risco >= 20 && risco <= 30)
                return (conta.Saldo * 0.03) * RETORNO_INVESTIMENTO;

            return (conta.Saldo * 0.006) * RETORNO_INVESTIMENTO;
        }
    }

    public class RealizadoraDeInvestimento
    {
        public double RealizarInvestimento(Conta conta, Investimento investimento)
        {
           return investimento.Calcular(conta);
        }
    }
}
