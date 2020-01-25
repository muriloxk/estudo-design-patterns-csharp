using System;
namespace ChainOfResponsability.Exemplo
{
    public class SemDesconto : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Calcular(Orcamento orcamento)
        {
            return 0;
        }
    }
}
