using System;

namespace Visitor.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressao = new Soma(new Numero(5), new Numero(2));
            var expressao2 = new Soma(expressao, new Numero(5));
            Console.WriteLine($"Expressão 2:  {expressao2.Avalia()}");

            var expressao3 = new Subtracao(expressao2, new Numero(200));
            Console.WriteLine($"Expressão 3: {expressao3.Avalia()}");

            var impressora = new Impressora();
            impressora.Visita(expressao2);
            impressora.Visita(expressao3);

            Console.ReadKey();
        }
    }

    public interface IVisitor
    {
        void Visita(IExpressao expressao);
        void VisitaSoma(Soma expressao);
        void VisitaSubtracao(Subtracao expressao);
        void VisitaMultiplicacao(Multiplicacao expressao);
        void VisitaDivisao(Divisao expressao);
        void VisitaRaizQuadrada(RaizQuadrada expressao);
        void VisitaNumero(Numero expressao);
    }

    public class ImpressoraAlternativa : IVisitor
    {
        public void Visita(IExpressao expressao)
        {
            expressao.Aceita(this);
        }

        public void VisitaDivisao(Divisao expressao)
        {
            Console.Write("(");
            Console.Write(" / ");
            expressao.Esquerda.Aceita(this);
            Console.Write(" ");
            expressao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void VisitaMultiplicacao(Multiplicacao expressao)
        {
            Console.Write("(");
            Console.Write(" * ");
            expressao.Esquerda.Aceita(this);
            Console.Write(" ");
            expressao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void VisitaNumero(Numero expressao)
        {
            Console.Write(expressao.Valor);
        }

        public void VisitaRaizQuadrada(RaizQuadrada expressao)
        {
            Console.Write(" ^ ");
            expressao.Aceita(this);
        }

        public void VisitaSoma(Soma expressao)
        {
            Console.Write("(");
            Console.Write(" + ");
            expressao.Esquerda.Aceita(this);
            Console.Write(" ");
            expressao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void VisitaSubtracao(Subtracao expressao)
        {
            Console.Write("(");
            Console.Write(" - ");
            expressao.Esquerda.Aceita(this);
            Console.Write(" ");
            expressao.Direita.Aceita(this);
            Console.Write(")");
        }
    }

    public class Impressora : IVisitor
    {
        public void Visita(IExpressao expressao)
        {
            expressao.Aceita(this);
        }

        public void VisitaSoma(Soma expressao)
        {
            Console.Write("(");
            expressao.Esquerda.Aceita(this);
            Console.Write(" + ");
            expressao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void VisitaDivisao(Divisao expressao)
        {
            Console.Write("(");
            expressao.Esquerda.Aceita(this);
            Console.Write(" / ");
            expressao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void VisitaMultiplicacao(Multiplicacao expressao)
        {
            Console.Write("(");
            expressao.Esquerda.Aceita(this);
            Console.Write(" * ");
            expressao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void VisitaRaizQuadrada(RaizQuadrada expressao)
        {
            Console.Write("(");
            Console.Write(" ^ ");
            expressao.Aceita(this);
            Console.Write(")");
        }


        public void VisitaSubtracao(Subtracao expressao)
        {
            Console.Write("(");
            expressao.Esquerda.Aceita(this);
            Console.Write(" - ");
            expressao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void VisitaNumero(Numero expressao)
        {
            Console.Write(expressao.Valor);
        }
    }

    public interface IExpressao
    {
        int Avalia();
        void Aceita(IVisitor visitor);
    }


    public class Numero : IExpressao
    {
        public int Valor { get; private set; }

        public Numero(int numero)
        {
            Valor = numero;
        }

        public int Avalia()
        {
            return Valor;
        }

        public void Aceita(IVisitor visitor)
        {
            visitor.VisitaNumero(this);
        }
    }

    public class Subtracao : IExpressao
    {
        public IExpressao Esquerda { get; private set; }
        public IExpressao Direita { get; private set; }

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

        public void Aceita(IVisitor visitor)
        {
            visitor.VisitaSubtracao(this);
        }
    }

    public class Soma : IExpressao
    {
        public IExpressao Esquerda { get;  private set; }
        public IExpressao Direita { get;  private set; }

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

        public void Aceita(IVisitor visitor)
        {
            visitor.VisitaSoma(this);
        }
    }

    public class Multiplicacao : IExpressao
    {
        public IExpressao Esquerda { get; private set; }
        public IExpressao Direita { get; private set; }

        public Multiplicacao(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            var resultadoExpressao1 = Esquerda.Avalia();
            var resultadoExpressao2 = Direita.Avalia();

            return resultadoExpressao1 * resultadoExpressao2;
        }

        public void Aceita(IVisitor visitor)
        {
            visitor.VisitaMultiplicacao(this);
        }
    }


    public class Divisao : IExpressao
    {
        public IExpressao Esquerda { get; private set; }
        public IExpressao Direita { get; private set; }

        public Divisao(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            var resultadoExpressao1 = Esquerda.Avalia();
            var resultadoExpressao2 = Direita.Avalia();

            return resultadoExpressao1 / resultadoExpressao2;
        }

        public void Aceita(IVisitor visitor)
        {
            visitor.VisitaDivisao(this);
        }
    }

    public class RaizQuadrada : IExpressao
    {
        public int Numero { get; private set; }

        public RaizQuadrada(IExpressao numero)
        {
            Numero = numero.Avalia();
        }

        public int Avalia()
        {
            return (int)Math.Sqrt(Numero);
        }

        public void Aceita(IVisitor visitor)
        {
            visitor.VisitaRaizQuadrada(this);
        }
    }
}



