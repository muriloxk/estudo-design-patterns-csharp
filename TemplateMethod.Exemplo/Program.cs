using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateMethod.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var orcamento = new Orcamento(500,
                new List<Item>()
                {
                    new Item(100, "Borracha"),
                    new Item(200, "Lapis"),
                    new Item(300, "Caderno"),
                    new Item(500, "Estoujo"),
                    new Item(500, "Estoujo")
                }
            );

            Console.WriteLine($"Calculo do imposto IKCV: { new IKCV().Calcula(orcamento) }");
            Console.WriteLine($"Calculo do imposto ICPP: { new ICPP().Calcula(orcamento) }");
            Console.WriteLine($"Calculo do imposto ICPP: { new IHIT().Calcula(orcamento) }");
            Console.ReadKey();
        }
    }

    public class Orcamento
    {
        public Orcamento(double valor, List<Item> itens)
        {
            Valor = valor;
            Itens = itens;
        }

        public double Valor { get; set; }
        public List<Item> Itens { get; set; }
    }

    public class Item
    {
        public Item(double valor, string descricao)
        {
            Valor = valor;
            Descricao = descricao;
        }

        public double Valor { get; set; }
        public string Descricao { get; set; }
    }

    public interface Imposto
    {
        public double Calcula(Orcamento orcamento);
    }

    public abstract class TemplateDeImpostoCondicional : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            if (DeveUsarMaximaTaxacao(orcamento))
            {
                return MaximaTaxacao(orcamento);
            }

            return MinimaTaxacao(orcamento);
        }

        protected abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
        protected abstract double MaximaTaxacao(Orcamento orcamento);
        protected abstract double MinimaTaxacao(Orcamento orcamento);
    }

    public class IKCV : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500 && TemItemMaiorQue100ReaisNo(orcamento);
        }

        private bool TemItemMaiorQue100ReaisNo(Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Valor > 100)
                    return true;
            }

            return false;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.10;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }

    public class ICPP : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }

    public class IHIT : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return possuiDoisItensComOmesmoNome(orcamento.Itens);
        }

        private bool possuiDoisItensComOmesmoNome(List<Item> itens)
        {
            var repetidos = itens.GroupBy(p => p.Descricao).Where(g => g.Count() > 1).ToList();
            return repetidos.Count() > 0;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }
}
