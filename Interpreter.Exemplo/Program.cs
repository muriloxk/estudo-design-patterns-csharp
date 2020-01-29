using System;

namespace Interpreter.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressao = new Soma(new Numero(5), new Numero(2));
            var expressao2 = new Soma(expressao, new Numero(5));
            Console.WriteLine($"Expressão 2:  {expressao2.Avalia()}" );

            var expressao3 = new Subtracao(expressao2, new Numero(200));
            Console.WriteLine($"Expressão 3: {expressao3.Avalia()}");

            Console.ReadKey();
        }
    }

    public interface IExpressao
    {
        int Avalia();
    }

    public class Numero : IExpressao
    {
        private int Valor { get; set; }

        public Numero(int numero)
        {
            Valor = numero;
        }

        public int Avalia()
        {
            return Valor;
        }
    }

    public class Subtracao
    {
        private IExpressao Esquerda { get; set; }
        private IExpressao Direita { get; set; }

        public Subtracao(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            var resultadoExpressao1 = Esquerda.Avalia();
            var resultadoExpressao2 = Direita.Avalia();

            return resultadoExpressao1 - resultadoExpressao2;
        }
    }

    public class Soma : IExpressao
    {
        private IExpressao Esquerda { get; set; }
        private IExpressao Direita { get; set; }

        public Soma(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            var resultadoExpressao1 = Esquerda.Avalia();
            var resultadoExpressao2 = Direita.Avalia();

            return resultadoExpressao1 + resultadoExpressao2;
        }
    }
}
