using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Decorator.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var orcamento = new Orcamento();
            orcamento.AdicionarItem("Lápis", 5);
            orcamento.AdicionarItem("Pincel", 15);

            var calcularIcmsComIss = new ICMS(new ISS());
            Console.WriteLine(calcularIcmsComIss.Calcular(orcamento));

            var calcularIcmsComIMA = new ICMS(new IMA());
            Console.WriteLine(calcularIcmsComIMA.Calcular(orcamento));

            Console.ReadKey();
        }
    }

    public class Orcamento
    {
        private Dictionary<string, double> itens;

        public double Valor
        {
            get
            {
                return itens.Sum(x => x.Value);
            }

            private set { }
        }

        public ReadOnlyDictionary<string, double> Itens
        {
            get
            {
                return new ReadOnlyDictionary<string, double>(itens);
            }

            private set { }
        }

        public void AdicionarItem(string descricao, double valor)
        {
            itens.Add(descricao, valor);
        }

        public Orcamento()
        {
            itens = new Dictionary<string, double>();
        }
    }

    public abstract class Imposto
    {
        protected Imposto(Imposto proximo)
        {
            Proximo = proximo;
        }

        protected Imposto()
        {
            Proximo = null;
        }

        protected Imposto Proximo { get; private set; }

        protected double CalculoDoProximo(Orcamento orcamento)
        {
            if (Proximo == null)
                return 0;

            return Proximo.Calcular(orcamento);
        }

        public abstract double Calcular(Orcamento orcamento);
    }

    public class ICMS : Imposto
    {
        public ICMS(Imposto proximo) : base(proximo) { }
      
        public ICMS() : base() { }
 
        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07 + CalculoDoProximo(orcamento);
        }
    }

    public class ISS : Imposto
    {
        public ISS(Imposto proximo) : base (proximo) { }
        public ISS() : base () { }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05 + CalculoDoProximo(orcamento);
        }
    }

    public class IMA : Imposto
    {
        public IMA(Imposto proximo) : base(proximo) { }
        public IMA() : base () { }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.2 + CalculoDoProximo(orcamento);
        }
    }

    public class ICPP : Imposto
    {
        public ICPP(Imposto proximo) : base(proximo) { }
        public ICPP() : base() { }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.2 + CalculoDoProximo(orcamento);
        }
    }

    public class IKCV : Imposto
    {
        public IKCV(Imposto proximo) : base(proximo) { }
        public IKCV() : base() { }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.2 + CalculoDoProximo(orcamento);
        }
    }
}
