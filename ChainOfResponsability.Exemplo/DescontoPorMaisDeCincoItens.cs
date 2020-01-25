using System;
namespace ChainOfResponsability.Exemplo
{
    public class DescontoPorMaisDeCincoItens : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Calcular(Orcamento orcamento)
        {
            if (orcamento.Itens.Count > 5)
                return orcamento.Valor * 0.1;

            return Proximo.Calcular(orcamento);
        }
    }
}
