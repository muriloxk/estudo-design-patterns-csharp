using System;

namespace ChainOfResponsability.Exemplo2
{
    public class PagamentoNuBank : PagamentoBancoChain
    {

        public PagamentoNuBank() : base(EBanco.NuBank)
        {

        }

        protected override void Pagar(Debito debito)
        {
            Console.WriteLine("Pagamento realizado via NuBank");
        }
    }
}
