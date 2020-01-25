using System;

namespace ChainOfResponsability.Exemplo2
{
    public class PagamentoItau : PagamentoBancoChain
    {

        public PagamentoItau() : base(EBanco.Itau)
        {

        }

        protected override void Pagar(Debito debito)
        {
            Console.WriteLine("Pagamento realizado via Itau");
        }
    }
}
