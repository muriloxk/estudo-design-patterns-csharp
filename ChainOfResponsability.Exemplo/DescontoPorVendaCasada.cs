using System;
namespace ChainOfResponsability.Exemplo
{
    public class DescontoPorVendaCasada : IDesconto
    {
        public IDesconto Proximo { get; set; }
        
        public double Calcular(Orcamento orcamento)
        {
            if (Existe("Caneta", orcamento) && Existe("Lapis", orcamento))
                return orcamento.Valor * 0.05;

            return Proximo.Calcular(orcamento);
        }

        private bool Existe(String nomeDoItem, Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Key.ToUpper().Equals(nomeDoItem.ToUpper()))
                    return true;
            }

            return false;
        }
    }
}
