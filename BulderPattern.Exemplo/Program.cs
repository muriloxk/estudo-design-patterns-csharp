﻿using System;
using System.Collections.Generic;

namespace BulderPattern.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        { 
            NotaFiscal nf = new NotaFiscalBuilder().ParaEmpresa("Caelum")
                                                   .ComCnpj("123.456.789/0001-10")
                                                   .Com(new ItemDaNota("item 1", 100.0))
                                                   .Com(new ItemDaNota("item 2", 200.0))
                                                   .Com(new ItemDaNota("item 3", 300.0))
                                                   .ComObservacoes("entregar nf pessoalmente")
                                                   .Constroi();
        }
    }

    // Utilizamos aqui o builder pattern com fluent interface;
    class NotaFiscalBuilder
    {
        public String RazaoSocial { get; private set; }
        public String Cnpj { get; private set; }
        public double ValorTotal { get; private set; }
        public double Impostos { get; private set; }
        public String Observacoes { get; private set; }

        private IList<ItemDaNota> todosItens = new List<ItemDaNota>();

        private DateTime? _date = null;
        public DateTime Data
        {
            get
            {
                if (_date == null)
                    return DateTime.Now;

                return _date.Value;
            }

            private set {
                _date = value;
            }
        }

        public NotaFiscalBuilder ParaEmpresa(String razaoSocial)
        {
            RazaoSocial = razaoSocial;
            return this; // retorno eu mesmo, o próprio builder, para que o cliente continue utilizando
        }

        public NotaFiscalBuilder ComCnpj(String cnpj)
        {
            Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder Com(ItemDaNota item)
        {
            todosItens.Add(item);
            ValorTotal += item.Valor;
            Impostos += item.Valor * 0.05;
            return this;
        }

        public NotaFiscalBuilder ComObservacoes(String observacoes)
        {
            Observacoes = observacoes;
            return this;
        }

        public NotaFiscalBuilder NaData(DateTime date)
        {
            Data = date;
            return this;
        }

        public NotaFiscal Constroi()
        {
            return new NotaFiscal(RazaoSocial, Cnpj, Data, ValorTotal, Impostos, todosItens, Observacoes);
        }
    }

    public class NotaFiscal
    {
        private String RazaoSocial { get;  set; }
        private String Cnpj { get;  set; }
        private DateTime DataDeEmissao { get;  set; }
        private double ValorBruto { get;  set; }
        private double Impostos { get;  set; }
        private IList<ItemDaNota> Itens { get;  set; }
        private String Observacoes { get;  set; }

        public NotaFiscal(String razaoSocial,
                        String cnpj,
                        DateTime dataDeEmissao,
                      double valorBruto,
                      double impostos,
                      IList<ItemDaNota> itens,
                      String observacoes)
        {
            this.RazaoSocial = razaoSocial;
            this.Cnpj = cnpj;
            this.DataDeEmissao = dataDeEmissao;
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
            this.Itens = itens;
            this.Observacoes = observacoes;
        }
    }

    //Só pra praticar o conceito, item da nota era uma classe simples de se c
    public class ItemDaNotaBuilder
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }

        public ItemDaNotaBuilder ComDecricao(string descricao)
        {
            this.Descricao = descricao;
            return this;
        }

        public ItemDaNotaBuilder ComValor(double valor)
        {
            this.Valor = valor;
            return this;
        }

        public ItemDaNota Constroi()
        {
            return new ItemDaNota(Descricao, Valor);
        }
    }

    public class ItemDaNota
    {
        public ItemDaNota(string descricao, double valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}
