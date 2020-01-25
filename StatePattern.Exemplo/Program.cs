using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StatePattern.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var orcamento = new Orcamento();
            orcamento.AdicionarItem("Canetas", 1_000);

            orcamento.Aprovar();
            orcamento.RealizarDesconto();
            Console.WriteLine(orcamento.Liquido);
            orcamento.Finalizar();
            Console.WriteLine(orcamento.Liquido);
            orcamento.Reprovar();

            Console.ReadKey();
        }
    }

    public abstract class EstadoOrcamento
    {
        protected Orcamento Orcamento { get; private set; }

        protected EstadoOrcamento(Orcamento orcamento)
        {
            Orcamento = orcamento;
        }

        public abstract void Aprovar();
        public abstract void Reprovar();
        public abstract void Finalizar();
        public abstract void RealizarDesconto();
    }

    public class EmAprovacao : EstadoOrcamento
    {
        public EmAprovacao(Orcamento orcamento) : base(orcamento) { }

        public override void Aprovar()
        {
            Orcamento.MudarEstado(new Aprovado(Orcamento));
            Console.WriteLine("Orcamento aprovado");
        }

        public override void Reprovar()
        {
            Orcamento.MudarEstado(new Reprovado(Orcamento));
            Console.WriteLine("Orcamento reprovado");
        }

        public override void Finalizar()
        {
            Orcamento.MudarEstado(new Finalizado(Orcamento));
            Console.WriteLine("Orcamento finalizado");
        }

        public override void RealizarDesconto()
        {
            Orcamento.Desconto = Orcamento.Valor * 0.05;
        }
    }

    public class Aprovado : EstadoOrcamento
    {
        public Aprovado(Orcamento orcamento) : base(orcamento) { }

        public override void Aprovar()
        {
            throw new Exception("O orçamento já está aprovado");
        }

        public override void Reprovar()
        {
            throw new Exception("O orçamento já está aprovado");
        }

        public override void Finalizar()
        {
            Orcamento.MudarEstado(new Finalizado(Orcamento));
            Console.WriteLine("Orcamento finalizado");
        }

        public override void RealizarDesconto()
        {
            Orcamento.Desconto = Orcamento.Valor * 0.07;
        }
    }

    public class Reprovado : EstadoOrcamento
    {
        public Reprovado(Orcamento orcamento) : base(orcamento) { }

        public override void Aprovar()
        {
            throw new Exception("O orçamento já está reprovado");
        }

        public override void Reprovar()
        {
            throw new Exception("O orçamento já está reprovado");
        }

        public override void Finalizar()
        {
            Orcamento.MudarEstado(new Finalizado(Orcamento));
            Console.WriteLine("Orcamento finalizado");
        }

        public override void RealizarDesconto()
        {
            throw new Exception("O orçamento já está reprovado");
        }
    }

    public class Finalizado : EstadoOrcamento
    {
        public Finalizado(Orcamento orcamento) : base(orcamento) { }

        public override void Aprovar()
        {
            throw new Exception("O orçamento já está finalizado");
        }

        public override void Reprovar()
        {
            throw new Exception("O orçamento já está finalizado");
        }

        public override void Finalizar()
        {
            throw new Exception("O orçamento já está finalizado");
        }

        public override void RealizarDesconto()
        {
            throw new Exception("O orçamento já está finalizado");
        }
    }

    public class Orcamento
    {

        private EstadoOrcamento Estado { get; set; }
        private Dictionary<string, double> itens;

        private double _desconto; 
        public double Desconto
        {
            get
            {
                return _desconto;
            }
            set
            {
                if (_desconto > 0)
                    throw new Exception("O orçamento já sofreu desconto");

                _desconto = value;
            }
        }

        public double Liquido
        {
            get
            {
                return Valor - Desconto;
            }

            private set { }
        }

        public Orcamento()
        {
            itens = new Dictionary<string, double>();
            MudarEstado(new EmAprovacao(this));
        }

        public void Aprovar()
        {
            Estado.Aprovar();
        }

        public void Reprovar()
        {
            Estado.Reprovar();
        }

        public void Finalizar()
        {
            Estado.Finalizar();
        }

        public double Valor
        {
            get
            {
                return itens.Sum(x => x.Value);
            }

            set { }
        }

        public ReadOnlyDictionary<string, double> Itens
        {
            get
            {
                return new ReadOnlyDictionary<string, double>(itens);
            }

            private set { }
        }

        public void RealizarDesconto()
        {
            Estado.RealizarDesconto();
        }

        public void AdicionarItem(string descricao, double valor)
        {
            itens.Add(descricao, valor);
        }

        public void MudarEstado(EstadoOrcamento estado)
        {
            Estado = estado;
        }
    }
}
