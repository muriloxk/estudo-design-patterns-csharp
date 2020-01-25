using System;
namespace ChainOfResponsability.Exemplo
{
    public class DescontoAcimaDeQuinhetos : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Calcular(Orcamento orcamento)
        {
            if (orcamento.Valor > 500.0)
                return orcamento.Valor * 0.07;

            return Proximo.Calcular(orcamento);
        }
    }
}
