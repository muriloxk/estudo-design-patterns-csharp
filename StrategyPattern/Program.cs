using System;

namespace StrategyPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var orcamento = new Orcamento(500);
            var calculadoraImpostos = new CalculadoraImpostos();
            var ICMS = calculadoraImpostos.Calcular(orcamento, new ICMS());
            var ISS = calculadoraImpostos.Calcular(orcamento, new ISS());
            var ICCC = calculadoraImpostos.Calcular(orcamento, new ICCC());

            Console.WriteLine(ICMS);
            Console.WriteLine(ISS);
            Console.WriteLine(ICCC);

            Console.ReadKey();
        }
    }

    public class Orcamento
    {
        public Orcamento(double valor)
        {
            Valor = valor;
        }

        public double Valor { get; set; }
    }

    public class CalculadoraImpostos
    {
        public Double Calcular(Orcamento orcamento, Imposto imposto)
        {
           return imposto.Calcular(orcamento);
        }
    }

    public interface Imposto
    {
        double Calcular(Orcamento orcamento);
    }

    public class ICMS : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }

    public class ICCC : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000)
                return orcamento.Valor * 0.05;

            if (orcamento.Valor >= 1000 && orcamento.Valor <= 3000)
                return orcamento.Valor * 0.07;

         
            return orcamento.Valor * 0.08 + 30;
        }
    }

    public class ISS : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06 + 50;
        }
    }
}
