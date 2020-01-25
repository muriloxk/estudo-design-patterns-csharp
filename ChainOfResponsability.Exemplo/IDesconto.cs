using System;
namespace ChainOfResponsability.Exemplo
{
    public interface IDesconto
    {
        IDesconto Proximo { get; set; }
        double Calcular(Orcamento orcamento);
    }
}
