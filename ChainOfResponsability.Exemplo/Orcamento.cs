using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChainOfResponsability.Exemplo
{
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
}
